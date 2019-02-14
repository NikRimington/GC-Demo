using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Umbraco.Core;
using Umbraco.Core.Cache;

namespace GrowCreate.Core.CurrencyConversion
{
    public class CurrencyConverter
    {
        private readonly CacheHelper cacheHelper;

        public CurrencyConverter(CacheHelper cacheHelper)
        {
            this.cacheHelper = cacheHelper;
        }

        public decimal Convert(decimal basePrice, decimal rate)
        {
            return basePrice * rate;
        }

        public Dictionary<string, decimal> GetRates(string baseCurrencyCode, string[] alternativeCodes)
        {
            var cachedRates = cacheHelper.RuntimeCache.GetCacheItem<Dictionary<string, decimal>>("ExchangeRates", () => GetRatesFromFixer(baseCurrencyCode, alternativeCodes), timeout: new TimeSpan(1, 0, 0));
            if (alternativeCodes.Any(a => cachedRates.ContainsKey(a) == false))
                GetMissingRates(baseCurrencyCode, cachedRates, alternativeCodes.Where(a => cachedRates.ContainsKey(a) == false));

            return cachedRates;
        }

        private void GetMissingRates(string baseCode, Dictionary<string, decimal> cachedRates, IEnumerable<string> alternativeCodes)
        {
            var missingRates = GetRatesFromFixer(baseCode, alternativeCodes.ToArray());
            foreach (var enty in missingRates)
                cachedRates.Add(enty.Key, enty.Value);

            UpdateCache(cachedRates);
        }

        private void UpdateCache(Dictionary<string, decimal> cachedRates)
        {
            cacheHelper.RuntimeCache.ClearCacheItem("ExchangeRates");
            cacheHelper.RuntimeCache.InsertCacheItem("ExchangeRates", () => cachedRates, timeout: new TimeSpan(1, 0, 0));
        }

        private Dictionary<string, decimal> GetRatesFromFixer(string baseCode, string[] alternativeCodes)
        {
            var apiKey = System.Configuration.ConfigurationManager.AppSettings["Fixer.API"];
            var baseUrl = "http://data.fixer.io/api/";
            var res = new Dictionary<string, decimal>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var codes = new List<string>{ baseCode };
                codes.AddRange(alternativeCodes);
                var url = string.Format("latest?access_key={0}&symbols={1}", apiKey, string.Join(",",codes));

                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawResponse = response.Content.ReadAsStringAsync().Result;
                    var responseObject = JsonConvert.DeserializeObject<FixerResponse>(rawResponse);
                    var ratio = 1.0M / responseObject.Rates[baseCode];
                    foreach (var alt in alternativeCodes)
                        res.Add(alt, responseObject.Rates[alt] * ratio);
                }
                else
                {
                    foreach (var alt in alternativeCodes)
                        res.Add(alt, 0.25m);
                }
            } 

            return res;

        }

    }
}

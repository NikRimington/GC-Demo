using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Web.Mvc;

namespace GrowCreate.Core.CurrencyConversion
{
    [PluginController("GrowCreate")]
    public class ConversionController : SurfaceController
    {

        public ConversionController()
        {

        }

        [ChildActionOnly]
        public ActionResult Convert(ConversionRequest req)
        {
            var currencyConverter = new CurrencyConverter(ApplicationContext.ApplicationCache);
            var results = new List<PriceEntry>();
            var rates = currencyConverter.GetRates(req.BaseCurrencyCode, req.AlternativeCurrencies.ToArray());
            foreach(var currencyCode in req.AlternativeCurrencies)
            {
                results.Add(new PriceEntry
                {
                    Currency = currencyCode.ToUpper(),
                    Price = currencyConverter.Convert(req.BasePrice, rates[currencyCode])
                });
            }
            return PartialView("AlternativePrices", results);
        }

    }
}

using System.Collections.Generic;

namespace GrowCreate.Core.CurrencyConversion
{
    public class ConversionRequest
    {
        public decimal BasePrice { get; set; }
        public string BaseCurrencyCode { get; set; }
        public IEnumerable<string> AlternativeCurrencies { get; set; }
    }
}

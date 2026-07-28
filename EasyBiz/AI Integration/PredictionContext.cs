using System;
using System.Collections.Generic;

namespace EasyBiz
{
    public class PredictionContext
    {
        public string TransactionType { get; set; }
        public int? AccountId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime Date { get; set; }
    }

    public class PredictionResult
    {
        public string Particulars { get; set; }
        public string Source { get; set; }
        public List<string> AlternateSuggestions { get; set; } = new();
    }
}
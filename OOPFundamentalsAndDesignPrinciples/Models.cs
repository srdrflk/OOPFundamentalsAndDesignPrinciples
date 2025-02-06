using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFundamentalsAndDesignPrinciples
{
    public class Models
    {
        public abstract class Document
        {
            public string DocumentNumber { get; set; }
            public string Title { get; set; }
            public string[] Authors { get; set; }
            public DateTime DatePublished { get; set; }
            public DateTime ExpirationDate { get; set; }
        }

        public class Patent : Document
        {
            public DateTime ExpirationDate { get; set; }
            public string UniqueId { get; set; }
        }

        public class Book : Document
        {
            public string ISBN { get; set; }
            public int NumberOfPages { get; set; }
            public string Publisher { get; set; }
            public DateTime ExpirationDate { get; set; }
        }

        public class LocalizedBook : Book
        {
            public string OriginalPublisher { get; set; }
            public string CountryOfLocalization { get; set; }
            public string LocalPublisher { get; set; }
            public DateTime ExpirationDate { get; set; }
        }
        public class Magazine : Document
        {
            public string Publisher { get; set; }
            public int ReleaseNumber { get; set; }
            public DateTime ExpirationDate { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPFundamentalsAndDesignPrinciples.Models;

namespace OOPFundamentalsAndDesignPrinciples
{
    public class CacheConfiguration
    {
        public Dictionary<Type, TimeSpan?> CacheExpiration { get; } = new();

        public CacheConfiguration()
        {
            // Default cache configuration
            CacheExpiration[typeof(Patent)] = TimeSpan.FromMinutes(10);
            CacheExpiration[typeof(Book)] = TimeSpan.FromMinutes(5);
            CacheExpiration[typeof(LocalizedBook)] = TimeSpan.FromMinutes(7);
            CacheExpiration[typeof(Magazine)] = TimeSpan.Zero;          // Magazines are not cached
        }
    }
}

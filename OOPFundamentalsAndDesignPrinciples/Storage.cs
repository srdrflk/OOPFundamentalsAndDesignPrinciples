using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static OOPFundamentalsAndDesignPrinciples.Models;

namespace OOPFundamentalsAndDesignPrinciples
{
    public class Storage
    {
        private readonly string _storagePath;
        private readonly MemoryCache _cache;
        private readonly CacheConfiguration _cacheConfig;

        public Storage(string storagePath, CacheConfiguration cacheConfig)
        {
            _storagePath = storagePath;
            _cacheConfig = cacheConfig;
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        // Search for documents by document number
        public List<Document> SearchByDocumentNumber(string documentNumber)
        {
            var documents = new List<Document>();
            var files = Directory.GetFiles(_storagePath, $"*_#{documentNumber}.json");

            foreach (var file in files)
            {
                var cacheKey = Path.GetFileNameWithoutExtension(file);
                if (_cache.TryGetValue(cacheKey, out Document cachedDoc))
                {
                    documents.Add(cachedDoc);
                }
                else
                {
                    var json = File.ReadAllText(file);
                    var document = DeserializeDocument(json);
                    if (document != null)
                    {
                        documents.Add(document);
                        CacheDocument(cacheKey, document);
                    }
                }
            }

            return documents;
        }

        private void CacheDocument(string cacheKey, Document document)
        {
            var cacheExpiration = _cacheConfig.CacheExpiration.GetValueOrDefault(document.GetType());

            if (cacheExpiration != TimeSpan.Zero) // Skip caching if expiration is zero
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = cacheExpiration
                };
                _cache.Set(cacheKey, document, cacheEntryOptions);
            }
        }

        // Deserialize JSON to the appropriate document type
        private Document DeserializeDocument(string json)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            if (json.Contains("\"UniqueId\""))
            {
                return JsonSerializer.Deserialize<Patent>(json, options);
            }
            else if (json.Contains("\"CountryOfLocalization\""))
            {
                return JsonSerializer.Deserialize<LocalizedBook>(json, options);
            }
            else if (json.Contains("\"ISBN\""))
            {
                return JsonSerializer.Deserialize<Book>(json, options);
            }
            else if (json.Contains("\"ReleaseNumber\""))
            {
                return JsonSerializer.Deserialize<Magazine>(json, options);
            }

            return null;
        }
    }
}

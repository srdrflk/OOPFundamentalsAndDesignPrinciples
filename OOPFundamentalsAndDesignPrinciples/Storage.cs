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

        public Storage(string storagePath)
        {
            _storagePath = storagePath;
        }

        // Search for documents by document number
        public List<Document> SearchByDocumentNumber(string documentNumber)
        {
            var documents = new List<Document>();
            var files = Directory.GetFiles(_storagePath, $"*_#{documentNumber}.json");

            foreach (var file in files)
            {
                var json = File.ReadAllText(file);
                var document = DeserializeDocument(json);
                if (document != null)
                {
                    documents.Add(document);
                }
            }

            return documents;
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

            return null;
        }
    }
}

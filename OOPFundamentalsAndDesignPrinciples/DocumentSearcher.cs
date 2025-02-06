using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPFundamentalsAndDesignPrinciples.Models;

namespace OOPFundamentalsAndDesignPrinciples
{
    public class DocumentSearcher
    {
        private readonly Storage _storage;

        public DocumentSearcher(Storage storage)
        {
            _storage = storage;
        }

        public List<Document> Search(string documentNumber)
        {
            return _storage.SearchByDocumentNumber(documentNumber);
        }
    }
}

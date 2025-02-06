using OOPFundamentalsAndDesignPrinciples;
using System;
using System.Collections.Generic;
using static OOPFundamentalsAndDesignPrinciples.Models;

namespace FileCabinetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cacheConfig = new CacheConfiguration();
            var storage = new Storage("C:\\Users\\Serdar_Filik\\Desktop\\DotNetBasicMentorProjects\\OOPFundamentalsAndDesignPrinciples\\Documents", cacheConfig); // Path to the folder containing document files
            
            var searcher = new DocumentSearcher(storage);

            Console.WriteLine("File Search");
            Console.WriteLine("Enter document number to search:");

            string documentNumber = Console.ReadLine();

            var results = searcher.Search(documentNumber);

            if (results.Count == 0)
            {
                Console.WriteLine("No documents found.");
            }
            else
            {
                Console.WriteLine($"Found {results.Count} document(s):");
                //foreach (var doc in results)
                //{
                //    Console.WriteLine($"Type: {doc.GetType().Name}, Title: {doc.Title}, Authors: {string.Join(", ", doc.Authors)}");
                //}
                foreach (var doc in results)
                {
                    Console.WriteLine($"Type: {doc.GetType().Name}, Title: {doc.Title}, Authors: {string.Join(", ", doc.Authors)}");

                    switch (doc)
                    {
                        case LocalizedBook localizedBook:
                            Console.WriteLine($"  ISBN: {localizedBook.ISBN}, Original Publisher: {localizedBook.OriginalPublisher}, Local Publisher: {localizedBook.LocalPublisher}, Expiration Date: {localizedBook.ExpirationDate:yyyy-MM-dd}");
                            break;

                        case Patent patent:
                            Console.WriteLine($"  Unique ID: {patent.UniqueId}, Expiration Date: {patent.ExpirationDate:yyyy-MM-dd}");
                            break;

                        case Book book:
                            Console.WriteLine($"  ISBN: {book.ISBN}, Publisher: {book.Publisher}, Pages: {book.NumberOfPages}, Expiration Date: {book.ExpirationDate:yyyy-MM-dd}");
                            break;

                        case Magazine magazine:
                            Console.WriteLine($"  Publisher: {magazine.Publisher}, Release Number: {magazine.ReleaseNumber}, Expiration Date: {magazine.ExpirationDate:yyyy-MM-dd}");
                            break;
                    }

                }
            }
        }
    }
}
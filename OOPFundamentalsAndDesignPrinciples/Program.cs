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
            var storage = new Storage("C:\\Users\\Serdar_Filik\\Desktop\\DotNetBasicMentorProjects\\OOPFundamentalsAndDesignPrinciples\\Documents"); // Path to the folder containing document files
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
                foreach (var doc in results)
                {
                    Console.WriteLine($"Type: {doc.GetType().Name}, Title: {doc.Title}, Authors: {string.Join(", ", doc.Authors)}");
                }
                
            }
        }
    }
}
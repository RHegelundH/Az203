using _6Connect._2Search.Model;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;

namespace _6Connect._2Search
{
    class Program
    {
        static void Main(string[] args)
        {
            string adminApiKey = "413596AD886A67BDB0E83D05BE099343";

            SearchServiceClient serviceClient = new SearchServiceClient("search-emails", new SearchCredentials(adminApiKey));

            ISearchIndexClient indexClient = serviceClient.Indexes.GetClient("email");

            var emails = new Email[]
            {
                new Email
                {
                    EmailId = Guid.NewGuid().ToString(),
                    Subject = "Subject1",
                    Message = "Hello search",
                    Sender = "sender@rhegelundh.com",
                    Receiver = "receiver@rhegelundh.com"
                },
            };

            var actions = new List<IndexAction<Email>>();
            foreach (var email in emails)
                actions.Add(new IndexAction<Email>(email));

            var batch = IndexBatch.New(actions);
            try
            {
                indexClient.Documents.Index(batch);
            }
            catch(IndexBatchException ibe)
            {
                Console.WriteLine("Exception: " + ibe.Message);
            }
        }
    }
}

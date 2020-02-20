using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _6Connect._2Search.Model
{
    public partial class Email
    {
        [System.ComponentModel.DataAnnotations.Key]
        [IsFilterable]
        public string EmailId { get; set; }

        [IsFilterable]  //Can search with an exact match (Case-sensitive)
        [IsSearchable]  //Can search more flexible
        [IsFacetable]   //Can drill-down if tree-search is enabled
        [IsSortable]    //Can sort by this field
        [Analyzer(AnalyzerName.AsString.DaLucene)]  //what does an analyzer?
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
    }
}

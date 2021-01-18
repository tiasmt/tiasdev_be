using System;

namespace backend.Models
{
    public class BlogPostOverview
    {
        public string Date { get; set; }
        public string ImageURL {get;set;}
        public string Summary { get; set; }
        public string Category {get;set;}
        public int Id {get;set;}
        public string Title {get;set;}
    }
}

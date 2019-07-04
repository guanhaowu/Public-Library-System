using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS
{
    class Book
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        [JsonProperty(PropertyName = "pages")]
        public int Pages { get; set; }
        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }
        [JsonProperty(PropertyName = "imageLink")]
        public string ImageLink { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        public Book(string author, string country, string imageLink, string language, string link, int pages, string title, int year)
        {
            this.Author = author; 
            this.Country = country;
            this.ImageLink = imageLink;
            this.Language = language;
            this.Link = link;
            this.Pages = pages;
            this.Title = title;
            this.Year = year;
        }
    }
}

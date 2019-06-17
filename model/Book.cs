using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS
{
    class Book
    {
        public string Title;
        public string Author;
        public string Description;
        public int Amount;
        public string PublishYear;
        public string ISBN;
        public string[] Genre;
        public string Edition;

        public Book(string Title, string Author, string Description, int Amount, string PublishYear, string ISBN, string[] Genre, string Edition)
        {
            this.Title = Title;
            this.Author = Author; 
            this.Description = Description;
            this.Amount = Amount;
            this.PublishYear = PublishYear;
            this.ISBN = ISBN;
            this.Genre = Genre;
            this.Edition = Edition;
        }
    }
}

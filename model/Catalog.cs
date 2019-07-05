using PLS.model;
using System.Collections.Generic;


namespace PLS
{
    class Catalog
    {
        Data data = new Data();
        public List<BookItem> Bookitem = new List<BookItem>();

        List<BookItem> searchResult = new List<BookItem>();

        public Catalog() { this.Bookitem = data.UploadBooks(); }

        public List<BookItem> GetAllBooks()
        {
            return Bookitem;
        }

        //search by title
        public List<BookItem> SearchBooksByTitle(string title)
        {
            searchResult.Clear();
            foreach (var book in Bookitem)
            {
                if (book.Title.Contains(title))
                {
                    searchResult.Add(book);
                }
            }
            return searchResult;
        }

        public List<BookItem> SearchBooksByAuthor(string author)
        {
            searchResult.Clear();
            foreach (var book in Bookitem)
            {
                if (book.Author.Contains(author))
                {
                    searchResult.Add(book);
                }
            }
            return searchResult;
        }

        public List<BookItem> SearchBooksByAuthorAndTitle(string title, string author)
        {
            searchResult.Clear();
            foreach (var book in Bookitem)
            {
                if (book.Author.Contains(author) && book.Title.Contains(title))
                {
                   searchResult.Add(book);
                }
            }
            return searchResult;
        }
    }
}

namespace PLS.model
{
    public class BookItem:Book
    {
        public int Id { get; set; }
        public static int Count = 0;
        public BookItem(string author, string country, string imageLink, string language, string link, int pages, string title, int year) : base(author, country, imageLink, language, link, pages, title, year)
        {
            this.Id = Count++;
        }

        public string GetBooks()
        {
            return string.Format(" ID: {0} \n Title: {1} \n  Author: {2} \n  Country: {3} \n  Language: {4} \n  Publish Year: {5} \n  Pages: {6} \n  Image Location: {7} \n  Website: {8} \n", this.Id, Title, Author, Country, Language, Year, Pages, ImageLink, Link);
        }
    }
}

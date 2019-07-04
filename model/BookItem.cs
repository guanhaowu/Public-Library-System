namespace PLS.model
{
    class BookItem:Book
    {
        public int Id { get; set; }
        public static int Count = 0;
        private int Amount { get; set; }
        public BookItem(string author, string country, string imageLink, string language, string link, int pages,
            string title, int year, int amount) : base(author, country, imageLink, language, link, pages, title, year)
        {
            this.Amount = amount;
            this.Id = ++Count;
        }

        public string GetAllBook()
        {
            return "Book Id: " + this.Id + "\n"+
                   "Title: " + this.Title + "\n"+
                   "Author: " + this.Author + "\n"+
                   "Year: " + this.Year + "\n";
        }
    }
}

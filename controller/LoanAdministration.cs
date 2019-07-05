using Newtonsoft.Json;
using PLS.model;
using System;
using System.Collections.Generic;
using System.IO;

namespace PLS
{
    public class LoanAdministration
    {
        Data data = new Data();
        Catalog Shelf = new Catalog();

        public List<Customer> customers = new List<Customer>();
        public List<BookItem> books = new List<BookItem>();

        [JsonProperty]
        private Dictionary<int, int> LoanedBooks = new Dictionary<int, int>();

        public LoanAdministration()
        {
            this.customers = data.UploadCustomer();
            this.books = data.UploadBooks();
        }

        // Methods:
        public void SearchAuthor(string author)
        {
            var result = Shelf.SearchBooksByAuthor(author);
            if (result.Count > 0)
            {
                foreach (var x in result)
                {
                    Console.WriteLine(x.GetBooks());
                }
            }
            else
            {
                Console.WriteLine("No author have been found by the name of: "+ author);
            }
        }

        public void SearchTitle(string title)
        {
            var result = Shelf.SearchBooksByTitle(title);
            if (result.Count > 0)
            {
                foreach (var x in result)
                {
                    Console.WriteLine(x.GetBooks());
                }
            }
            else
            {
                Console.WriteLine("No book have been found by the title: "+ title);
            }
        }

        public void SearchBookByAuthAndTitle(string author, string title)
        {
            var result = Shelf.SearchBooksByAuthorAndTitle(title, author);
            if (result.Count > 0)
            {
                foreach (var x in result)
                {
                    Console.WriteLine(x.GetBooks());
                }
            }
            else
            {
                Console.WriteLine("No result have been found.");
            }            
        }

        public void lendBook(int bookId, int customerId)
        {
            if (LoanedBooks.ContainsKey(bookId))
            {
                Console.WriteLine("This book is being borrowed by someone else at the moment, try again later...");
            }
            else
            {
                LoanedBooks.Add(bookId, customerId);
            }
        }

        public void GetAllBooksOnLoan(List<BookItem> books, List<Customer> customers)
        {
            Console.WriteLine("These books are on loan:");
            foreach (var book in books)
            {
                foreach (int id in LoanedBooks.Keys)
                {
                    if (book.Id == id)
                        Console.WriteLine(" Book Id: " + book.Id + " Book title: " + book.Title);
                        Console.WriteLine(" Borrowed by Customer Id: " + customers[LoanedBooks[id]].Number + " Customer name: " + customers[LoanedBooks[id]].SurName + " " + customers[LoanedBooks[id]].LastName);
                }
            }
        }

        public void GetAllBooks()
        {
            var result = Shelf.GetAllBooks();
            foreach (var x in result) { Console.WriteLine(x.GetBooks()); }
        }

        public void addBook()
        {
            Console.WriteLine("Author: ");
            string author = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("Country: ");
            string country = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("ImageLink Location: ");
            string imageLink = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("Language: ");
            string language = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("Link url: ");
            string linkurl = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("Total Pages: ");
            int pages = int.Parse(Console.ReadLine());
            Console.WriteLine("Book Title: ");
            string bookTitle = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("Publish Year: ");
            int pubYear = int.Parse(Console.ReadLine());

            try
            {
                AddBook(new BookItem(author, country, imageLink, language, linkurl, pages, bookTitle, pubYear));
                Console.WriteLine("Book has been succesfully added.");
            }
            catch { Console.WriteLine("Failed to add a new book."); }
        }

        public void AddBook(BookItem book)
        {
            books.Add(book);
            var json = JsonConvert.SerializeObject(books);
            File.WriteAllText(Data.NewBookFile, json);
            data.ApplySettings(0);
        }

        public List<Customer> GetAllCustomer()
        {
            foreach ( var x in customers)
            {
                Console.WriteLine(x.GetCustomer());
            }
            return customers;
        }

        public void GetCustomer(int i)
        {
            int total_records = customers.Count;
            string s = "";
            if (i <= total_records && i > 0)
            {
                s = customers[i - 1].GetCustomer();
            }
            else
            {
                s = "Input is too high";
            }
            Console.WriteLine(s);
        }

        public void addCustomer()
        {
            Console.WriteLine("Surname: ");
            string surName = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("Last name: ");
            string lastName = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("Gender: ");
            string gender = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("Nationality: ");
            string nationality = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("Street address: ");
            string street = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("Postcode: ");
            string postcode = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("City: ");
            string city = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("Email: ");
            string email = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("Username: ");
            string username = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("Phone number: ");
            string telephoneNum = Console.ReadLine().Replace("\"","");

            int number = data.UploadCustomer().Count + 1;
            AddCustomer(new Customer(number, gender, nationality, lastName, surName, street, postcode, city, email, username, telephoneNum));
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
            var jsonSerializer = new JsonSerializer();
            using (var writer = new StreamWriter(Data.NewPersonFile))
            using (var jsonwriter = new JsonTextWriter(writer))
            {
                jsonSerializer.Serialize(jsonwriter, customers);
            }
            data.ApplySettings(1);
        }

        public void Backup()
        {
            Console.WriteLine("Executing Backup... \nPlease wait...");
            var jsonSerializer = new JsonSerializer();
            
            //Customer file
            using (var writer = new StreamWriter(Data.backup_NewPersonFile))
            using (var jsonwriter = new JsonTextWriter(writer))
            {
                jsonSerializer.Serialize(jsonwriter, customers);
            }

            //Book file
            using (var writer = new StreamWriter(Data.backup_NewBookFile))
            using (var jsonwriter = new JsonTextWriter(writer))
            {
                jsonSerializer.Serialize(jsonwriter, books);
            }
            Console.WriteLine("Backup successfully executed...");

        }
    }
}

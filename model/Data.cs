using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS
{
    class Data
    {
        // Default folder location
        const string BookFile = @"~\Data\books.json";
        const string PersonFile = @"~\Data\persons.csv";
   
        public List<Book> GetData() 
        {
            var books = new List<Book>();

            using (StreamReader reader = new StreamReader("C:/Users/guanh/Desktop/Github/Public-Library-System/Data/books.json"))
            {
                string json = reader.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }
            return books;
        }

        public void SaveBook(Book book) 
        {
            var books = GetData();
            books.Add(book);

            var json = JsonConvert.SerializeObject(books);
            File.WriteAllText(@"Data/savedbooks.json", json);
        }
        
/*
        public void getAuthors() {
            string[] AuthLines = File.ReadAllLines(AuthorsFile);
            foreach (string line in AuthLines)
            {
                // Read a text file line by line.  
                Console.WriteLine(line);
            }
        }
        public void setAuthors()
        {
            string[] AuthLines = File.ReadAllLines(AuthorsFile);

            foreach (string line in AuthLines)
            {
                // Read a text file line by line.  
                Console.WriteLine(line);
            }
        }
*/



    }
}

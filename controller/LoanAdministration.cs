using Newtonsoft.Json;
using PLS.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS
{
    class LoanAdministration
    {
        Data data = new Data();
        public List<Customer> Customers = new List<Customer>();

        public LoanAdministration() { }

        // Methods:
        public void LendBook() { }
        public void AddBook(string Title, string Author, string Description, int Amount, string PublishYear, string ISBN, string[] Genre, string Edition) { }
        public string[] SearchBook(string[] args) {
            string[] result;
            result = args;
            return result;
        }

        public string GetCustomer(int i)
        {
            return Customers[i].GetCustomer(); // still not showing records in console for now...
        }

        public void AddCustomer()
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
            var customers = data.UploadCustomer();
            customers.Add(customer);
            var jsonSerializer = new JsonSerializer();
            using (var writer = new StreamWriter(Data.NewPersonFile))
            using (var jsonwriter = new JsonTextWriter(writer))
            {
                jsonSerializer.Serialize(jsonwriter, customers);
            }
            data.ApplySettings(1);
        }

        public void addBook(Book book)
        {
            var books = data.UploadBooks();
            books.Add(book);
            var json = JsonConvert.SerializeObject(books);
            File.WriteAllText(Data.NewBookFile, json);
            data.ApplySettings(0);
        }

        public void Backup()
        {
            var jsonSerializer = new JsonSerializer();
            
            //Customer file
            var customers = data.UploadCustomer();
            using (var writer = new StreamWriter(Data.backup_NewPersonFile))
            using (var jsonwriter = new JsonTextWriter(writer))
            {
                jsonSerializer.Serialize(jsonwriter, customers);
            }

            //Book file
            var books = data.UploadBooks();
            using (var writer = new StreamWriter(Data.backup_NewBookFile))
            using (var jsonwriter = new JsonTextWriter(writer))
            {
                jsonSerializer.Serialize(jsonwriter, customers);
            }

        }
    }
}

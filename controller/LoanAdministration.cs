using PLS.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS
{
    class LoanAdministration
    {
        public LoanAdministration() { }

        // Methods:
        public void LendBook() { }
        public void AddBook(string Title, string Author, string Description, int Amount, string PublishYear, string ISBN, string[] Genre, string Edition) { }
        public string[] SearchBook(string[] args) {
            string[] result;
            result = args;
            return result;
        }

        public string GetCustomer(string[] args)
        {
            return args[0].ToString(); //unfinished
        }

        public void AddCustomer()
        {
            Console.WriteLine("Surname: ");
            string surName = Console.Read().ToString();
            Console.WriteLine("Last name: ");
            string lastName = Console.Read().ToString();
            Console.WriteLine("Gender: ");
            string gender = Console.Read().ToString();
            Console.WriteLine("Nationality: ");
            string nationality = Console.Read().ToString();
            Console.WriteLine("Street address: ");
            string street = Console.Read().ToString();
            Console.WriteLine("Postcode: ");
            string postcode = Console.Read().ToString();
            Console.WriteLine("City: ");
            string city = Console.Read().ToString();
            Console.WriteLine("Email: ");
            string email = Console.Read().ToString();
            Console.WriteLine("Phone number: ");
            string telephoneNum = Console.Read().ToString();

            Customer new_customer = new Customer(surName, lastName, gender, nationality, street, postcode, city, email, telephoneNum);
            new_customer.AddCustomer();
        }
    }
}

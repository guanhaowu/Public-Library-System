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
        Customer customer;
        public LoanAdministration() { }

        // Methods:
        public void LendBook() { }
        public void AddBook(string Title, string Author, string Description, int Amount, string PublishYear, string ISBN, string[] Genre, string Edition) { }
        public string[] SearchBook(string[] args) {
            string[] result;
            result = args;
            return result;
        }
        public string[] GetCustomer<a>(a args) {
            return customer.getName();
        }



    }
}

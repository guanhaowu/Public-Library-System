using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS.model
{
    class Customer : Person
    {
        private static int counter;
        private int customerNum { get; set; } = counter;

        public Customer(int number, string gender, string nationality, string lastName, string surName, string street, string postcode, string city, string email, string username, string telephoneNum): 
            base(number,gender, nationality, lastName, surName, street, postcode, city, email, telephoneNum)
        {

            AddCustomer();
        }

        // Method

        public void AddCustomer() {
            this.customerNum = counter + 1;
        }
    }
}

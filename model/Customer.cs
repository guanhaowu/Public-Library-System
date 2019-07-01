using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS.model
{
    class Customer : Person
    {
        private int customerNum;

        public Customer( string surName, string lastName, string gender, string nationality, string street, string postcode, string city, string email, string telephoneNum) : 
            base(surName, lastName, gender, nationality, street, postcode, city, email, telephoneNum)
        {
            
        }

        // Method
        public int getCustomerNum()
        {
            return this.customerNum;
        }

        public static string[] getAllCustomer() {
            string[] AllCustomer = { };
            return AllCustomer;
        }
        
        public void AddCustomer() {
            this.customerNum = customerNum + 1;
        }
    }
}

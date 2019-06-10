using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS.model
{
    class Customer : Person
    {
        private string Username;

        public Customer(
            string surName, string lastName, string gender, string nationality, string street,
            string postcode, string city, string email, string telephoneNum, string username 
            ) : base(surName, lastName, gender, nationality, street,
            postcode, city, email, telephoneNum)
        {

        }
    }
}

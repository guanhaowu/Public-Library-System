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

        public Customer( string surName, string lastName, string gender, string nationality, string street, string postcode, string city, string email, string telephoneNum, int customerNum ) : 
            base(surName, lastName, gender, nationality, street, postcode, city, email, telephoneNum)
        {
            this.customerNum = customerNum;
        }
    }
}

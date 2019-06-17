using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS.model
{
    class Librarian : Person
    {
        private int LibrarianId;
        public Librarian(string surName, string lastName, string gender, string nationality, string street, string postcode, string city, string email, string telephoneNum, int LibrarianId) :
            base(surName, lastName, gender, nationality, street, postcode, city, email, telephoneNum)
        {

        }
    }
}

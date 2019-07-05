using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS.model
{
    class Librarian : Person
    {
        private static int Counter;
        private int LibrarianId { get; set; } = Counter;
        public Librarian(int number, string gender, string nationality, string lastName, string surName, string street, string postcode, string city, string email, string username, string telephoneNum) :
            base(number, gender, nationality, lastName, surName, street, postcode, city, email, username, telephoneNum)
        {
            this.LibrarianId = ++Counter;
        }
    }
}

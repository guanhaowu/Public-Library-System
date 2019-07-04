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
        public Librarian(int number, string surName, string lastName, string gender, string nationality, string street, string postcode, string city, string email, string telephoneNum) :
            base(number, surName, lastName, gender, nationality, street, postcode, city, email, telephoneNum)
        {
            this.LibrarianId = ++Counter;
        }
    }
}

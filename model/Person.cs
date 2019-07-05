using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS
{
    public abstract class Person
    {
        public int Number { get; set; }
        public string Gender { get; set; }
        public string Nameset { get; set; } //Nationality
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string TelephoneNumber { get; set; }
        //Fields: Number,Gender,NameSet,GivenName,Surname,StreetAddress,ZipCode,City,EmailAddress,Username,TelephoneNumber

        public Person(int number, string gender, string nationality, string lastName, string surName, string street, string postcode, string city, string email, string username, string telephoneNum)
        {

        }
    }
}

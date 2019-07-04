using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS
{
    class Person
    {
        private int Number { get; set; }
        private string SurName { get; set; }
        private string LastName { get; set; }
        private string Gender { get; set; }
        private string Nameset { get; set; } //Nationality
        private string StreetAddress { get; set; }
        private string ZipCode { get; set; }
        private string City { get; set; }
        private string EmailAddress { get; set; }
        private string TelephoneNumber { get; set; }
        //Fields: Number,Gender,NameSet,GivenName,Surname,StreetAddress,ZipCode,City,EmailAddress,Username,TelephoneNumber

        public Person(int number, string gender, string nationality, string lastName, string surName, string street, string postcode, string city, string email, string telephoneNum)
        {
            this.Number = number;
            this.SurName = surName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Nameset = nationality;
            this.StreetAddress = street;
            this.ZipCode = postcode;
            this.City = city;
            this.EmailAddress = email;
            this.TelephoneNumber = telephoneNum;
        }
    }
}

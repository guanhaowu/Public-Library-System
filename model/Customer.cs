using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS.model
{
    public class Customer : Person
    {
        public Customer(int number, string gender, string nationality, string lastName, string surName, string street, string postcode, string city, string email, string username, string telephoneNum): 
            base(number, gender, nationality, lastName, surName, street, postcode, city, email, username, telephoneNum)
        {
            this.Number = number;
            this.Gender = gender;
            this.Nameset = nationality;
            this.LastName = lastName;
            this.SurName = surName;
            this.StreetAddress = street;
            this.ZipCode = postcode;
            this.City = city;
            this.EmailAddress = email;
            this.Username = username;
            this.TelephoneNumber = telephoneNum;
        }

        // Method
        public string GetCustomer()
        {
            return Number.ToString()+","+Gender+","+Nameset+ "," +LastName + "," + SurName + "," + StreetAddress + "," + ZipCode + "," + City + "," + EmailAddress + "," + Username + "," +TelephoneNumber;
        }
    }
}

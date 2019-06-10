﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS
{
    class Person
    {
        private static int PersonCounter;
        private int ID = PersonCounter;
        private string SurName;
        private string LastName;
        private string Gender;
        private string Nameset; //Nationality
        private string StreetAddress;
        private string ZipCode;
        private string City;
        private string EmailAddress;
        private string Username;
        private string TelephoneNumber;

        public Person(string surName, string lastName, string gender, string nationality, string street, string postcode, string city, string email, string telephoneNum)
        {
            this.ID = ++PersonCounter;
            this.SurName = surName;
            this.LastName = lastName;
            this.Gender = gender;

        }

        public string getSurName()
        {
            return this.SurName;
        }

        public string getLastName()
        {
            return this.LastName;
        }

        public string getDoB()
        {
            return this.Gender;
        }

        public int getID()
        {
            return this.ID;
        }

    }
}

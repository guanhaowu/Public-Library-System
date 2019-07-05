using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PLS.controller;
using PLS.model;

namespace PLS
{
    class Data
    {
        // Default folder location
        private static string workingDirectory = Environment.CurrentDirectory;
        private static string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        private static string SettingsFile = projectDirectory + "\\Data\\settings.json";
        private static readonly string InitialBookFile = projectDirectory + "\\Data\\books.json";
        private static readonly string NewBookFile = projectDirectory + "\\Data\\savedbooks.json";
        private static readonly string InitialPersonFile = projectDirectory + "\\Data\\persons.csv";
        private static readonly string NewPersonFile = projectDirectory + "\\Data\\persons.json";

        public List<Settings> GetSettings()
        {
            var settings = new List<Settings>();
            using (StreamReader reader = new StreamReader(SettingsFile))
            {
                var json = reader.ReadToEnd();
                settings = JsonConvert.DeserializeObject<List<Settings>>(json);
            }
            return settings;
        }

        public void ApplySettings(int index)
        {
            var setting = GetSettings();
            switch (index)
            {
                case 0:
                    setting[0].FirstRun_Book = false;
                    break;
                case 1:
                    setting[0].FirstRun_PersonList = false;
                    break;
            }
            var json = JsonConvert.SerializeObject(setting);
            File.WriteAllText(SettingsFile, json);
        }

        public List<Book> GetBookData()
        {
            var books = new List<Book>();

            string BookFile;
            var setting = GetSettings();
            BookFile = setting[0].FirstRun_Book ? InitialBookFile : NewBookFile;
            using (StreamReader reader = new StreamReader(BookFile))
            {
                var json = reader.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }
            return books;
        }

        public void SaveBook(Book book)
        {
            var books = GetBookData();
            books.Add(book);

            var json = JsonConvert.SerializeObject(books);
            File.WriteAllText(NewBookFile, json);

            ApplySettings(0);
        }

        public List<Customer> UploadCustomer()
        {
            var CustomerList = new List<Customer>();
            var FileLocation = GetSettings()[0].FirstRun_PersonList ? InitialPersonFile : NewPersonFile;
            var lines = File.ReadAllLines(FileLocation);
            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(',');
                CustomerList.Add(new Customer(
                    int.Parse(values[0]),
                    values[1].Replace("\"", ""),
                    values[2].Replace("\"", ""),
                    values[3].Replace("\"", ""),
                    values[4].Replace("\"", ""),
                    values[5].Replace("\"", ""),
                    values[6].Replace("\"", ""),
                    values[7].Replace("\"", ""),
                    values[8].Replace("\"", ""),
                    values[9].Replace("\"", ""),
                    values[10].Replace("\"", "")));
            }
            return CustomerList;
        }

        public void SaveCustomer(Customer customer)
        {
            var customers = UploadCustomer();
            customers.Add(customer);
            foreach (var x in customers)
            {
                Console.WriteLine(x.GetCustomer());
            }

            var json = JsonConvert.SerializeObject(customers);// result = {},{},{},{},....   instead filled objects.
            File.WriteAllText(NewPersonFile, json);//saves as [{},{},{},{},...] 
            //ApplySettings(1);
        }

    }
}

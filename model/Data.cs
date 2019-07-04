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
        private static readonly string NewPersonFile = projectDirectory + "\\Data\\persons.csv";

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
                    setting[index].FirstRun_Book = false;
                    break;
                case 1:
                    setting[index].FirstRun_PersonList = false;
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

        public List<Customer> GetCustomerList()
        {
            List<string[]> contentList = new List<string[]>();
            List<Customer> CustomerList = new List<Customer>();

            var FileLocation = GetSettings()[1].FirstRun_PersonList ? InitialPersonFile : NewPersonFile;
            using (StreamReader reader = new StreamReader(FileLocation))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] result = line.Split(new string[] {","}, StringSplitOptions.None);
                    contentList.Add(result);
                }
            }

            for (int i = 1; i < contentList.Count; i++)
            {
                CustomerList.Add(new Customer(Int32.Parse(contentList[i][0]), contentList[i][3], contentList[i][4], contentList[i][1], contentList[i][2], contentList[i][5], contentList[i][6], contentList[i][7], contentList[i][8], contentList[i][9],contentList[i][10]));
            }
            return CustomerList;
        }
        public void SaveCustomer(Customer customer)
        {
            var customers = GetCustomerList();
            customers.Add(customer);

            var json = JsonConvert.SerializeObject(customer);
            File.WriteAllText(NewBookFile, json);

            //ApplySettings(1);
        }

    }
}

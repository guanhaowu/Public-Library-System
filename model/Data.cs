using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PLS.model;

namespace PLS
{
    public class Data
    {
        // Default folder location
        private static string workingDirectory = Environment.CurrentDirectory;
        private static string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        private static string SettingsFile = projectDirectory + "\\Data\\settings.json";
        public static readonly string InitialBookFile = projectDirectory + "\\Data\\books.json";
        public static readonly string NewBookFile = projectDirectory + "\\Data\\savedbooks.json";
        public static readonly string InitialPersonFile = projectDirectory + "\\Data\\persons.csv";
        public static readonly string NewPersonFile = projectDirectory + "\\Data\\persons.json";
        public static readonly string TransactionFile = projectDirectory + "\\Data\\borrowList.json";

        //backup locations
        public static readonly string backup_NewBookFile = projectDirectory + "\\Data\\backup\\savedbooks.json";
        public static readonly string backup_NewPersonFile = projectDirectory + "\\Data\\backup\\persons.json";
        public static readonly string backup_TransactionFile = projectDirectory + "\\Data\\backup\\borrowList.json";

        public List<Settings> GetSettings()
        {
            var settings = new List<Settings>();
            try
            {
                using (StreamReader reader = new StreamReader(SettingsFile))
                {
                    var json = reader.ReadToEnd();
                    settings = JsonConvert.DeserializeObject<List<Settings>>(json);
                }
            }
            catch { Console.WriteLine("Failed to load Settings file..."); }
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

        public Dictionary<int,int> GetBorrowList()
        {
            Dictionary<int, int> LoanedBooks = new Dictionary<int, int>();
            try
            {
                using (StreamReader reader = new StreamReader(TransactionFile))
                {
                    var json = reader.ReadToEnd();
                    LoanedBooks = JsonConvert.DeserializeObject<Dictionary<int,int>>(json);
                }
            }
            catch { Console.WriteLine("Failed to load books file..."); }
            return LoanedBooks;
        }

        public Dictionary<int, int> restore_GetBorrowList()
        {
            Dictionary<int, int> LoanedBooks = new Dictionary<int, int>();
            try
            {
                using (StreamReader reader = new StreamReader(backup_TransactionFile))
                {
                    var json = reader.ReadToEnd();
                    LoanedBooks = JsonConvert.DeserializeObject<Dictionary<int, int>>(json);
                }
            }
            catch { Console.WriteLine("Failed to load books file..."); }
            return LoanedBooks;
        }

        public List<BookItem> UploadBooks()
        {
            var books = new List<BookItem>();

            string BookFile;
            var setting = GetSettings();
            BookFile = setting[0].FirstRun_Book ? InitialBookFile : NewBookFile;
            try
            {
                using (StreamReader reader = new StreamReader(BookFile))
                {
                    var json = reader.ReadToEnd();
                    books = JsonConvert.DeserializeObject<List<BookItem>>(json);
                }
            }
            catch { Console.WriteLine("Failed to load books file..."); }
            return books;
        }

        public List<BookItem> restore_UploadBooks()
        {
            var books = new List<BookItem>();
            try
            {
                using (StreamReader reader = new StreamReader(backup_NewBookFile))
                {
                    var json = reader.ReadToEnd();
                    books = JsonConvert.DeserializeObject<List<BookItem>>(json);
                }
            }
            catch { Console.WriteLine("Failed to load books file..."); }
            return books;
        }

        public List<Customer> UploadCustomer()
        {
            var CustomerList = new List<Customer>();
            if (GetSettings()[0].FirstRun_PersonList)
            {
                try
                {
                    var lines = File.ReadAllLines(InitialPersonFile);
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
                }
                catch { Console.WriteLine("Cannot find Initial Person file with the extension .csv."); }
            }
            else
            {
                try {
                    var fileContents = new List<string[]>();
                    using (StreamReader reader = new StreamReader(NewPersonFile))
                    {
                        var lines = reader.ReadToEnd();
                        CustomerList = JsonConvert.DeserializeObject<List<Customer>>(lines);
                    }
                }
                catch { Console.WriteLine("Failed to read Persons Json file."); }
            }
            return CustomerList;
        }

        public List<Customer> restore_UploadCustomer()
        {
            var CustomerList = new List<Customer>();
            try
            {
                var fileContents = new List<string[]>();
                using (StreamReader reader = new StreamReader(backup_NewPersonFile))
                {
                    var lines = reader.ReadToEnd();
                    CustomerList = JsonConvert.DeserializeObject<List<Customer>>(lines);
                }
            }
            catch { Console.WriteLine("Failed to read Persons Json file."); }
            return CustomerList;
        }
    }
}

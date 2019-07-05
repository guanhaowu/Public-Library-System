using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLS.controller;
using PLS.model;

namespace PLS
{
    /*By Guan Hao Wu
     *Student nummer: 0976154
     * 
     * -ReadMe
     *Main program 
     * -While loop met input
     * 
     * 
     * 
     * 
     * 
     * 
     */
    class Program
    {
        public static bool status = true;
        static void Main(string[] args)
        {   
            Console.Title = "Public Library System";
            Console.WriteLine("Welcome to the Public Library System");
            Console.WriteLine("Please type 'help' for more information.");
            Run();
        }
    
        public static void Run()
        {
            while (status == true)
            {
                LoanAdministration admin = new LoanAdministration();
                Data data = new Data();

                Console.Write("Command: ");
                string inputValue = Console.ReadLine();
                switch (inputValue)
                {
                    case "getData":
                        data.UploadBooks();
                        break;
                    case "saveBook":
                    {
                        var book = new Book("ATRS Botje", "Netherlands", "LeukBoek/boek1.jpg", "NL", "url", 129,
                            "Title1", 2019);
                        admin.addBook(book);
                        break;
                    }
                    case "getAllCustomer":
                    {
                        data.UploadCustomer();
                        break;
                    }
                    case "getCustomer":
                        Console.WriteLine("Which user id would you like to search?");
                        int i = int.Parse(Console.ReadLine());
                        admin.GetCustomer(i);
                        break;
                    case "addCustomer":
                    {
                        admin.AddCustomer();
                        break;
                    }
                        
                }

                Console.WriteLine(inputValue);
                Functions.actions(inputValue);
            }
        }
    } 
}

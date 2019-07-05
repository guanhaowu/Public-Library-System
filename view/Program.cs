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
                Data data = new Data();

                Console.Write("Command: ");
                string inputValue = Console.ReadLine();
                switch (inputValue)
                {
                    case "getData":
                        data.GetBookData();
                        break;
                    case "saveBook":
                    {
                        var book = new Book("ATRS Botje", "Netherlands", "LeukBoek/boek1.jpg", "NL", "url", 129,
                            "Title1", 2019);
                        data.SaveBook(book);
                        break;
                    }
                    case "getCustomer":
                    {
                        int numb = data.UploadCustomer().Count;
                        for(int i = 0; i < numb; i++)
                        {
                            Console.WriteLine(data.UploadCustomer()[i].GetCustomer());    
                        }
                        break;
                    }

                    case "saveCustomer":
                    {
                        int number = data.UploadCustomer().Count+1;
                        var _customers = new Customer(number,"Man", "Chinese", "Wu", "Guan", "goudeweg 124", "3042BD", "Rotterdam", "test@test.nl", "Test123" , "06-12345678");
                        data.SaveCustomer(_customers);
                        break;
                    }
                        
                }

                Console.WriteLine(inputValue);
                Functions.actions(inputValue);
            }
        }
    } 
}

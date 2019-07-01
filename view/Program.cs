using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLS.controller;

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
                        data.GetData();
                        break;
                    case "saveBook":
                    {
                        //string Title, string Author, string Description, int Amount, string PublishYear, string ISBN, string[] Genre, string Edition
                        var book = new Book("Berend Botje", "John Doe", "Leuk boek", 1, "1990", "12345", new string[] { "Horror"}, "3de");
                        data.SaveBook(book);
                        break;
                    }
                }

                Console.WriteLine(inputValue);
                Functions.actions(inputValue);
            }
        }
    } 
}

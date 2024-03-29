﻿using System;

namespace PLS
{
    public class Functions
    {
        Data data;
        LoanAdministration admin;
        public Functions(Data data, LoanAdministration admin)
        {
            this.data = data;
            this.admin = admin;
        }

        public void Actions(string inputValue)
        {
            switch (inputValue)
            {
                case "help":
                    {
                        getHelp();
                        break;
                    }
                case "quit":
                    {
                        Program.status = !Program.status;
                        break;
                    }
                case "getAllBooks":
                    {
                        admin.GetAllBooks();
                        break;
                    }
                case "addBook":
                    {
                        admin.addBook();
                        break;
                    }
                case "getAllCustomer":
                    {
                        foreach ( var x in admin.GetAllCustomer())
                        {
                            Console.WriteLine(x.GetCustomer());
                        }
                        break;
                    }
                case "getCustomer":
                    {
                        Console.WriteLine("Which user id would you like to search?");
                        int i = int.Parse(Console.ReadLine());
                        admin.GetCustomer(i);
                        break;
                    }
                case "addCustomer":
                    {
                        admin.addCustomer();
                        break;
                    }
                case "searchAuthor":
                    {
                        Console.WriteLine("Which Author would you like to search?");
                        string author = Console.ReadLine();
                        author.Trim();
                        admin.SearchAuthor(author);
                        break;
                    }
                case "searchTitle":
                    {
                        Console.WriteLine("Which Book title would you like to search?");
                        string title = Console.ReadLine();
                        title.Trim();
                        admin.SearchTitle(title);
                        break;
                    }
                case "searchBook":
                    {
                        Console.WriteLine("Which Book would you like to search?");
                        Console.WriteLine("Author name to search?");
                        string author = Console.ReadLine();
                        author.Trim();
                        Console.WriteLine("Book title to search?");
                        string title = Console.ReadLine();
                        title.Trim();
                        admin.SearchBookByAuthAndTitle(author, title);
                        break;
                    }
                case "allLoanedBooks":
                    {
                        //admin.GetAllBooksOnLoan(admin.GetAllBook(), admin.GetAllCustomer());
                        Console.WriteLine("Not fully functional yet...");
                        break;
                    }
                case "lendBook":
                    {
                        admin.GetAllBooks();
                        Console.WriteLine("Enter the ID of the book listed above that you want to loan to a customer:");
                        int bookID = int.Parse(Console.ReadLine());
                        admin.GetAllCustomer();
                        Console.WriteLine("Enter the number of the customer listed above that you want to loan a book to:");
                        int CustomerID = int.Parse(Console.ReadLine());
                        admin.lendBook(bookID, CustomerID);
                        break;
                    }
                case "backup":
                    {
                        admin.Backup();
                        break;
                    }
                case "restore":
                    {
                        admin.restore();
                        break;
                    }
            }
        }
        public static void getHelp()
        {
            Console.WriteLine("help : All available commands.");
            Console.WriteLine("getAllBooks: Returns all records of books.");
            Console.WriteLine("addBook: Add a new book record.");
            Console.WriteLine("getAllCustomer: Returns all records of Customer.");
            Console.WriteLine("getCustomer: Will be asked for a number to return a Customer with that number.");
            Console.WriteLine("addCustomer: Add a new Customer record to Customer.");
            Console.WriteLine("searchAuthor: Search book by Author name.");
            Console.WriteLine("searchTitle: Search book by book title.");
            Console.WriteLine("searchBook: Search book by Author name and book Title.");
            Console.WriteLine("lendBook: Lend a book to a customer.");
            Console.WriteLine("allLoanedBooks: Show list of borrowed books by which users.");
            Console.WriteLine("backup: Backup all JSON Files");
            Console.WriteLine("quit: Stop the program from running and exit the console.");
        }

    }
}

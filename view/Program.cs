using System;

namespace PLS
{
    /*By Guan Hao Wu
     *Student nummer: 0976154
     */
    class Program
    {
        public static bool status = true;
        static void Main(string[] args)
        {   
            Console.Title = "Public Library System";
            Console.WriteLine("Welcome to the Public Library System");
            Console.WriteLine("Please type 'help' for more information or type 'quit' to stop and exit this program.");
            Run();
        }
    
        public static void Run()
        {
            LoanAdministration admin = new LoanAdministration();
            Data data = new Data();
            Functions func = new Functions(data, admin);
            while (status == true)
            {
                Console.Write("Command: ");
                string inputValue = Console.ReadLine();
                func.Actions(inputValue);
            }
        }
    } 
}

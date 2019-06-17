using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLS
{
    class Functions
    {
        static readonly string rootFolder = @"C:\Temp\Backup\Data\";
        public void BackUp()
        {
            
            //backup the files into new location.

        }

        public static void getHelp()
        {
            Console.WriteLine("All available commands: ");
        }

        public static void actions(string inputValue)
        {
            if (inputValue == "help")
            {
                getHelp();
            }
            else if (inputValue == "quit")
            {
                Program.status = !Program.status;
            }
        }

    }
}

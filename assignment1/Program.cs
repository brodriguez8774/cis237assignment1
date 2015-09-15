using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVProcessor processFiles = new CSVProcessor();

            int wineListSizeInt = processFiles.WineListSize;



            UserInterface mainMenu = new UserInterface();
            WineItemCollection wineItemCollection = new WineItemCollection(wineListSizeInt);
            
        }
    }
}

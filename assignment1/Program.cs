using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">Command-Line args</param>
        static void Main(string[] args)
        {
            #region Variables

            // Classes
            UserInterface mainMenu;
            CSVProcessor processFiles;
            WineItemCollection wineItemCollection;

            // Input Variables
            int loadListSizeInt;                    // Number of items in file to load.

            // Working Variables
            bool runProgramBool;                    // Is true until user selects exit. Forces loop to keep program running.

            #endregion

            //Initializes Classes and Variables
            runProgramBool = true;
            processFiles = new CSVProcessor();
            loadListSizeInt = processFiles.WineListSize;
            wineItemCollection = new WineItemCollection(loadListSizeInt);



            mainMenu = new UserInterface(runProgramBool, loadListSizeInt, processFiles, wineItemCollection);

            #region Methods

            #endregion


            


            #region TestRegion
            /*
            #region WineItemTest

            Console.WriteLine(Environment.NewLine + "******************************" + Environment.NewLine +
                "Test For WineItem functionality." + Environment.NewLine +
                "******************************" + Environment.NewLine);

            int ID1 = 123;
            int ID2 = 456;
            string aDesc1 = "aDesc";
            string aDesc2 = "OtherDesc";
            string aSize1 = "Size 1";
            string aSize2 = "Size 500";

            WineItem WineTest1 = new WineItem(ID1, aDesc1, aSize1);
            WineItem WineTest2 = new WineItem(ID2, aDesc2, aSize2);

            Console.WriteLine("TEST- ForcePrint:" + Environment.NewLine +
                WineTest1.WineID + " " + WineTest1.WineDescription + " " + WineTest1.WineSize + Environment.NewLine);

            Console.WriteLine("TEST- ToString():");
            Console.WriteLine(WineTest1.ToString());
            Console.WriteLine(WineTest2.ToString());

            Console.WriteLine(Environment.NewLine);

            #endregion



            #region WineItemCollection

            Console.WriteLine(Environment.NewLine + "******************************" + Environment.NewLine +
                "Test For Collection functionality." + Environment.NewLine +
                "******************************" + Environment.NewLine);

            WineItemCollection collectionTest = new WineItemCollection(5);
            collectionTest.LoadWineItem(WineTest1, 0);
            collectionTest.LoadWineItem(WineTest2, 1);

            Console.WriteLine("TEST- Above items added to collection and displayed:");
            Console.WriteLine(collectionTest.GetCollectionToString());

            #endregion


            
            #region CSVProcessorTest

            Console.WriteLine(Environment.NewLine + "******************************"
             + Environment.NewLine + "Test For CSVProcessor functionality." + Environment.NewLine +
             "******************************" + Environment.NewLine);

            CSVProcessor loadThings = new CSVProcessor();

            int ArraySize = loadThings.WineListSize;
            Console.WriteLine("TEST- # of Items loaded: " + Environment.NewLine + ArraySize + Environment.NewLine);

            WineItemCollection wineCollection = new WineItemCollection(ArraySize);
            loadThings = new CSVProcessor(wineCollection);

            Console.WriteLine("TEST- Collection Contents After Load:");
            Console.WriteLine(wineCollection.GetCollectionToString());

            #endregion
            */
            #endregion
        }
    }
}

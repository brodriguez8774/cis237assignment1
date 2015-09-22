using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    /// <summary>
    /// Cordinates classes in program to behave properly.
    /// </summary>
    class RunProgram
    {
        #region Variables

        // Classes
        UserInterface mainMenu;
        CSVProcessor processFiles;
        WineItemCollection wineItemCollection;
        WineItem wineItem;

        // Input Variables
        private int loadListSizeInt;                    // Number of items in file to load.

        // Working Variables
        private bool runProgramBool;                    // Is true until user selects exit. Forces loop to keep program running.
        private string IDString;
        private bool collectionLoadedBool;              // Saves if file has been loaded or not.
        private int indexInt;

        // Constant Variables
        private int MAX_ID_LENGTH = 5;

        #endregion



        #region Constructor



        /// <summary>
        /// Base Constructor to run program.
        /// </summary>
        public RunProgram()
        {
            wineItem = new WineItem();
            runProgramBool = true;
            processFiles = new CSVProcessor();
            loadListSizeInt = processFiles.LoadListSize;
            wineItemCollection = new WineItemCollection(loadListSizeInt);
            mainMenu = new UserInterface();

            wineItem = new WineItem();
            while (runProgramBool)
            {
                mainMenu.PrintUserMenu();
                UserSelection();
            }
        }

        /// <summary>
        /// Constructor to force testing of individual classes.
        /// </summary>
        /// <param name="TestTrueBool">Bool to specify testing should occur.</param>
        public RunProgram(bool TestTrueBool)
        {
            Testing();
        }

        #endregion



        #region Methods

        /// <summary>
        /// Reads user input and takes appropriate action.
        /// </summary>
        private void UserSelection()
        {
            string userSelectionString = mainMenu.GetUserInput().ToLower();
            Console.WriteLine();

            switch (userSelectionString)
            {
                case "1":
                    LoadWineList();
                    break;

                case "2":
                    PrintWineList();
                    break;

                case "3":
                    SearchWineList();
                    break;

                case "4":
                    AddItemToList();
                    break;

                case "5":
                    RemoveItemFromList();
                    break;

                case "6":
                    CloseProgram();
                    break;

                case "esc":
                    CloseProgram();
                    break;

                default:
                    mainMenu.DisplayLine(Environment.NewLine + " Error, Invalid Selection!" + Environment.NewLine + " Please enter a number between 1 and 5.");
                    break;
            }
        }

        /// <summary>
        /// Handles Menu option 1. Loading from Wine List.
        /// </summary>
        private void LoadWineList()
        {
            // While has not been loaded yet.
            if (collectionLoadedBool == false)
            {
                indexInt = wineItemCollection.CurrentIndex;
                // If no items are present in the collection.
                if (wineItemCollection.WineItemArray[0] == null)
                {
                    processFiles = new CSVProcessor(wineItemCollection, indexInt);
                }
                else
                {
                    while (wineItemCollection.WineItemArray[indexInt] != null)
                    {
                        indexInt++;
                    }
                    processFiles = new CSVProcessor(wineItemCollection, indexInt);
                }
                collectionLoadedBool = true;
            }
            else
            {
                mainMenu.DisplayLine("Wine list has already been loaded.");
            }
        }

        /// <summary>
        /// Handles Menu option 2. Printing of Wine List.
        /// </summary>
        private void PrintWineList()
        {
            if (wineItemCollection.WineItemArray[0] != null)
            {
                mainMenu.DisplayLine(wineItemCollection.GetCollectionToString());
            }
            else
            {
                mainMenu.DisplayLine("List is currently empty.");
            }
        }

        /// <summary>
        /// Handles Menu option 3. Searching of Wine List.
        /// </summary>
        private void SearchWineList()
        {
            // Determines if there is a list to even search.
            if (wineItemCollection.WineItemArray[0] != null)
            {
                try
                {
                    mainMenu.DisplayLine("Enter ID to search for: ");
                    IDString = mainMenu.GetUserInput();

                    // Allows user to back out.
                    if (IDString.ToLower() != "esc")
                    {
                        wineItem = wineItemCollection.SearchWineItem(IDString, 0);
                        if (wineItem.WineDescription == "ID is Not Found")
                        {
                            mainMenu.DisplayLine("The entered ID (" + wineItem.WineID + ") is not found.");
                        }
                        else
                        {
                            mainMenu.DisplayLine("Match Found: " + wineItem.ToString());
                        }
                    }
                }
                catch
                {
                    mainMenu.DisplayLine("Error, invalid ID. Please enter 5 characters.");
                }
            }
            else
            {
                mainMenu.DisplayLine("There are no items to search. Please load a file or add items first.");
            }

        }

        /// <summary>
        /// Handles Menu option 4. Manually adding items to Wine List.
        /// </summary>
        private void AddItemToList()
        {
            try
            {
                mainMenu.DisplayLine(Environment.NewLine + "Enter Wine ID:  (ID should be 5 characters long)");
                IDString = mainMenu.GetUserInput();

                // Allows user to back out.
                if (IDString.ToLower() != "esc")
                {
                    if (IDString.Length == MAX_ID_LENGTH)
                    {
                        wineItem.WineID = IDString;

                        mainMenu.DisplayLine("Enter Wine Description:");
                        wineItem.WineDescription = mainMenu.GetUserInput();

                        mainMenu.DisplayLine("Enter Wine Pack Size:");
                        wineItem.WineSize = mainMenu.GetUserInput();

                        wineItemCollection.AddWineItem(wineItem);
                    }
                    else
                    {
                        mainMenu.DisplayLine("ID must be exactly 5 characters long.");
                    }
                }
            }
            catch
            {
                mainMenu.DisplayLine("Invalid input. ID must be a number.");
            }
        }

        /// <summary>
        /// Handles Menu option 5. Removing items from Wine List.
        /// </summary>
        private void RemoveItemFromList()
        {
            // Checks to see if there is anything to remove.
            if (wineItemCollection.WineItemArray[0] != null)
            {
                Console.WriteLine(Environment.NewLine + "Enter ID to remove: ");
                IDString = mainMenu.GetUserInput();

                // Allows user to back out.
                if (IDString.ToLower() != "esc")
                {
                    if (wineItemCollection.RemoveWineItem(IDString, 0))
                    {
                        mainMenu.DisplayLine("ID " + IDString + " successfully removed.");
                    }
                    else
                    {
                        mainMenu.DisplayLine("Could not locate ID to remove.");
                    }
                }
            }
            else
            {
                mainMenu.DisplayLine("There are no items to remove. Please load a file or add items first.");
            }
        }

        /// <summary>
        /// Handles Menu option 6. Closing the program.
        /// </summary>
        private void CloseProgram()
        {
            runProgramBool = false;
        }

        #endregion



        #region TestRegion

        /// <summary>
        /// For debugging/testing purposes. Bypasses UserInterface class and tests individual classes directly.
        /// </summary>
        private void Testing()
        {

            #region WineItemTest

            Console.WriteLine(Environment.NewLine + "******************************" + Environment.NewLine +
                "Test For WineItem functionality." + Environment.NewLine +
                "******************************" + Environment.NewLine);

            string ID1 = "12345";
            string ID2 = "67890";
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



            #region WineItemCollectionTest

            Console.WriteLine(Environment.NewLine + "******************************" + Environment.NewLine +
                "Test For Collection functionality." + Environment.NewLine +
                "******************************" + Environment.NewLine);

            WineItemCollection collectionTest = new WineItemCollection(5);
            collectionTest.LoadWineItem(WineTest1, 0, 1);
            collectionTest.LoadWineItem(WineTest2, 1, 1);

            Console.WriteLine("TEST- Above items added to collection and displayed:");
            Console.WriteLine(collectionTest.GetCollectionToString());

            #endregion



            #region CSVProcessorTest

            Console.WriteLine(Environment.NewLine + "******************************"
             + Environment.NewLine + "Test For CSVProcessor functionality." + Environment.NewLine +
             "******************************" + Environment.NewLine);

            CSVProcessor loadThings = new CSVProcessor();

            int ArraySize = loadThings.LoadListSize;
            Console.WriteLine("TEST- # of Items loaded: " + Environment.NewLine + ArraySize + Environment.NewLine);

            WineItemCollection wineCollection = new WineItemCollection(ArraySize);
            loadThings = new CSVProcessor(wineCollection, 0);

            Console.WriteLine("TEST- Collection Contents After Load:");
            Console.WriteLine(wineCollection.GetCollectionToString());

            #endregion

        }

        #endregion
    }
}

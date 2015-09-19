using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class UserInterface
    {
        #region Variables

        // Classes
        WineItem wineItem;
        WineItemCollection wineItemCollection;
        CSVProcessor processFiles;

        // Working Variables
        private bool runProgramBool;                    // Keeps program running.
        private bool collectionLoadedBool;              // Saves if file has been loaded or not.
        private int loadListSizeInt;
        private int indexInt;

        #endregion



        #region Constructors

        /// <summary>
        /// Base Constructor
        /// </summary>
        public UserInterface()
        {
            
        }

        /// <summary>
        /// Constructor to launch interface.
        /// </summary>
        /// <param name="runProgram">Continues running program if Boolean is true.</param>
        /// <param name="loadListSize">The size of the list in loadFile.</param>
        /// <param name="fileLoader">Class which loads files.</param>
        /// <param name="collection">Collection of Wine Items.</param>
        public UserInterface(bool runProgram, int loadListSize, CSVProcessor fileLoader, WineItemCollection collection)
        {
            RunProgram = runProgram;
            LoadListSize = loadListSize;
            FileLoader = fileLoader;
            Collection = collection;

            RunProgram = runProgram;
            RunMenu();
        }

        #endregion



        #region Properties

        public bool RunProgram
        {
            set
            {
                this.runProgramBool = value;
            }
            get
            {
                return runProgramBool;
            }
        }

        public int LoadListSize
        {
            set
            {
                this.loadListSizeInt = value;
            }
            get
            {
                return loadListSizeInt;
            }
        }

        private CSVProcessor FileLoader
        {
            set
            {
                this.processFiles = value;
            }
        }

        private WineItemCollection Collection
        {
            set
            {
                this.wineItemCollection = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Main loop to keep user in program until exit.
        /// </summary>
        private void RunMenu()
        {
            wineItem = new WineItem();
            while (runProgramBool)
            {
                DisplayMainMenu();
                UserSelection();
            }
        }

        /// <summary>
        /// Reusable menu to display to user.
        /// </summary>
        private void DisplayMainMenu()
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine +
                "   Choose an Option:" + Environment.NewLine +
                "   ~~~~~~~~~~~~~~~~~" + Environment.NewLine +
                "    1) Load Wine List" + Environment.NewLine +
                "    2) Print Wine List" + Environment.NewLine +
                "    3) Search for Item" + Environment.NewLine +
                "    4) Add New Item to List" + Environment.NewLine +
                "    5) Remove Item from List" + Environment.NewLine +
                "    6) Exit" + Environment.NewLine);
        }

        /// <summary>
        /// Reads user input and takes appropriate action.
        /// </summary>
        private void UserSelection()
        {
            string userSelectionString = Console.ReadLine().Trim();
            Console.WriteLine();
            WineItem wineItem = new WineItem();
            int IDint;

            switch (userSelectionString)
            {
                case "1":   // Load Wine List.
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
                            processFiles= new CSVProcessor(wineItemCollection, indexInt);
                        }
                        collectionLoadedBool = true;
                    }
                    else
                    {
                        Console.WriteLine("Wine list has already been loaded.");
                    }
                    break;
                    
                case "2":   // Print Wine List.
                    if (wineItemCollection.WineItemArray[0] != null)
                    {
                        Console.WriteLine(wineItemCollection.GetCollectionToString());
                    }
                    else
                    {
                        Console.WriteLine("List is currently empty.");
                    }
                    break;

                case "3":   // Search Wine List.
                    // Determines if there is a list to even search.
                    if (wineItemCollection.WineItemArray[0] != null)
                    {
                        try
                        {
                            Console.WriteLine("Enter ID to search for: ");
                            IDint = Convert.ToInt32(Console.ReadLine().Trim());

                            wineItem = wineItemCollection.SearchWineItem(IDint, 0);
                            if (wineItem.WineDescription == "ID is Not Found")
                            {
                                Console.WriteLine("The entered ID (" + wineItem.WineID + ") is not found.");
                            }
                            else
                            {
                                Console.WriteLine("Match Found: " + wineItem.ToString());
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Error, invalid ID. Please enter a 5 digit number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no items to search. Please load a file or add items first.");
                    }

                    
                    break;

                case "4":   // Add item to Wine List.
                    try
                    {
                        Console.WriteLine(Environment.NewLine + "Enter Wine ID:  (ID should be a 5 digit number)");
                        wineItem.WineID = Convert.ToInt32(Console.ReadLine().Trim());

                        Console.WriteLine("Enter Wine Description:");
                        wineItem.WineDescription = Console.ReadLine().Trim();

                        Console.WriteLine("Enter Wine Pack Size:");
                        wineItem.WineSize = Console.ReadLine().Trim();
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input. ID must be a number.");
                    }

                    wineItemCollection.AddWineItem(wineItem);
                    
                    break;

                case "5":   // Remove item from Wine List.
                    Console.WriteLine(Environment.NewLine + "Enter ID to remove: ");
                    IDint = Convert.ToInt32(Console.ReadLine());
                    if (wineItemCollection.RemoveWineItem(IDint, 0))
                    {
                        Console.WriteLine("ID " + IDint + " successfully removed.");
                    }
                    else
                    {
                        Console.WriteLine("Could not locate ID to remove.");
                    }


                    break;

                case "6":   // Exit.
                    runProgramBool = false;
                    break;

                default:
                    Console.WriteLine(Environment.NewLine + " Error, Invalid Selection!" + Environment.NewLine + " Please enter a number between 1 and 5.");
                    break;
            }
        }

        #endregion
    }
}

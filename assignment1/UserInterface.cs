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
        CSVProcessor processFiles;
        WineItemCollection wineItemCollection;
        WineItem wineItem;

        // Working Variables
        private bool runProgramBool;
        private bool collectionCreatedBool;

        #endregion



        #region Constructors

        public UserInterface()
        {
            runProgramBool = true;
            collectionCreatedBool = false;
            RunMenu();
        }

        public UserInterface(bool runProgram)
        {
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
        #endregion



        #region Methods

        /// <summary>
        /// Main loop to keep user in program until exit.
        /// </summary>
        private void RunMenu()
        {
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
                "    5) Exit" + Environment.NewLine);
        }

        /// <summary>
        /// Reads user input and takes appropriate action.
        /// </summary>
        private void UserSelection()
        {
            string userSelectionString = Console.ReadLine().Trim();

            switch (userSelectionString)
            {
                case "1":
                    processFiles = new CSVProcessor();
                    int arraySizeInt = processFiles.WineListSize;
                    wineItemCollection = new WineItemCollection(arraySizeInt);
                    processFiles = new CSVProcessor();
                    collectionCreatedBool = true;
                    break;

                case "2":
                    if (collectionCreatedBool)
                    {
                        wineItemCollection.GetCollectionToString();
                    }
                    else
                    {
                        Console.WriteLine("Collection is currently empty.");
                        collectionCreatedBool = true;
                    }
                    break;

                case "3":

                    break;

                case "4":
                    WineItem wineItem = new WineItem();

                    try
                    {
                        Console.WriteLine(Environment.NewLine + "Enter Wine ID:");
                        wineItem.WineID = Convert.ToInt32(Console.ReadLine().Trim());

                        Console.WriteLine("Enter Wine Description:");
                        wineItem.WineDescription = Console.ReadLine().Trim();

                        Console.WriteLine("Enter Wine Pack Size:");
                        wineItem.WineDescription = Console.ReadLine().Trim();
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input. ID must be a number.");
                    }
                    break;

                case "5":
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

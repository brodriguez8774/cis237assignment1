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

        private bool runProgramBool = true;

        #endregion



        #region Constructors

        public UserInterface()
        {
            
        }

        #endregion



        #region Properties

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
            Console.WriteLine("Choose an Option:" + Environment.NewLine +
                "1) Load Wine List" + Environment.NewLine +
                "2) Print Wine List" + Environment.NewLine +
                "3) Search for Item" + Environment.NewLine +
                "4) Add New Item to List" + Environment.NewLine +
                "5) Exit" + Environment.NewLine);
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
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    runProgramBool = false;
                    break;
                default:
                    Console.WriteLine("Invalid Selection. Please enter a number between 1 and 5.");
                    break;
            }
        }

        #endregion
    }
}

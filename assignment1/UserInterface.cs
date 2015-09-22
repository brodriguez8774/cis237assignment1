using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    /// <summary>
    /// Controls the entire interface for user.
    /// </summary>
    class UserInterface
    {
        #region Variables

        // Working Variables
        private string userInputString;

        #endregion



        #region Constructors

        /// <summary>
        /// Base Constructor
        /// </summary>
        public UserInterface()
        {

        }

        #endregion



        #region Properties

        public string UserSelection
        {
            get
            {
                return userInputString;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Displays Main Menu for user.
        /// </summary>
        public void PrintUserMenu()
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine +
                "   Choose an Option:" + "          Note:"+ Environment.NewLine +
                "   ~~~~~~~~~~~~~~~~~" + "          You may type 'esc' at any point to back out." + Environment.NewLine +
                "    1) Load Wine List" + Environment.NewLine +
                "    2) Print Wine List" + Environment.NewLine +
                "    3) Search for Item" + Environment.NewLine +
                "    4) Add New Item to List" + Environment.NewLine +
                "    5) Remove Item from List" + Environment.NewLine +
                "    6) Exit" + Environment.NewLine);
        }

        /// <summary>
        /// Method to display line to user. Single method creates consistancy in UI.
        /// </summary>
        /// <param name="displayString">The string to display.</param>
        public void DisplayLine(string displayString)
        {
            Console.WriteLine(displayString);
        }

        /// <summary>
        /// Reads user input from console.
        /// </summary>
        /// <returns>String of user input.</returns>
        public string GetUserInput()
        {
            try
            {
                userInputString = Console.ReadLine().Trim();
            }
            catch (Exception errmsg)
            {
                userInputString = "Error," + Environment.NewLine + errmsg;
            }
            return userInputString;
        }

        #endregion
    }
}

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

        private void DisplayMainMenu()
        {
            Console.WriteLine("Choose an Option:" + Environment.NewLine +
                "1) Load Wine List" + Environment.NewLine +
                "2) Print Wine List" + Environment.NewLine +
                "3) Search for Item" + Environment.NewLine +
                "4) Add New Item to List" + Environment.NewLine +
                "5) Exit" + Environment.NewLine);
        }

        private void RunMenu()
        {
            while (runProgramBool == true)
            {

            }
        }

        #endregion
    }
}

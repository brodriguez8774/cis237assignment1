using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class WineItem
    {
        #region Variables

        // Input Variables
        private int wineIDInt;
        private string wineDescriptionString;
        private string wineSizeString;

        #endregion



        #region Constructors

        public WineItem()
        {

        }

        public WineItem(int wineID, string wineDescription, string wineSize)
        {
            WineID = wineID;
            WineDescription = wineDescription;
            WineSize = wineSize;
        }

        #endregion



        #region Properties

        public int WineID
        {
            set
            {
                wineIDInt = value;
            }
            
            get
            {
                return this.wineIDInt;
            }
        }

        public string WineDescription
        {
            set
            {
                wineDescriptionString = value;
            }

            get
            {
                return this.wineDescriptionString;
            }
        }

        public string WineSize
        {
            set
            {
                wineSizeString = value;
            }

            get
            {
                return this.wineSizeString;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// String Override to display WineItem information.
        /// </summary>
        /// <returns>Returns Item's ID, Description, and Pack size.</returns>
        public override string ToString()
        {
            return this.wineIDInt + ", " +
                this.wineDescriptionString + ", " +
                this.wineSizeString + " ";
        }

        #endregion
    }
}

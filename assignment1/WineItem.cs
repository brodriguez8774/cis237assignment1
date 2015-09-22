using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    /// <summary>
    /// Creates and holds information for individual Wine Items.
    /// </summary>
    class WineItem
    {
        #region Variables

        // Input Variables
        private string wineIDInt;
        private string wineDescriptionString;
        private string wineSizeString;

        #endregion



        #region Constructors

        /// <summary>
        /// Base Constructor.
        /// </summary>
        public WineItem()
        {

        }

        /// <summary>
        /// Constructor that fills in WineItem information.
        /// </summary>
        /// <param name="wineID">Item's desired ID.</param>
        /// <param name="wineDescription">Item's desired Description.</param>
        /// <param name="wineSize">Item's desired Pack Size.</param>
        public WineItem(string wineID, string wineDescription, string wineSize)
        {
            WineID = wineID;
            WineDescription = wineDescription;
            WineSize = wineSize;
        }

        #endregion



        #region Properties

        public string WineID
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

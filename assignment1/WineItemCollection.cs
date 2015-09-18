using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class WineItemCollection
    {
        #region Variables

        // Classes
        WineItem wineItem;

        // Input Variables
        private int lengthOfArrayInt;
        private int indexInt;

        private WineItem[] wineItemArray;

        #endregion



        #region Constructors

        /// <summary>
        /// Base Constructor.
        /// </summary>
        public WineItemCollection()
        {

        }

        /// <summary>
        /// Create Array Constructor.
        /// </summary>
        /// <param name="wineListSize">Size of wine List.</param>
        public WineItemCollection(int wineListSize)
        {
            lengthOfArrayInt = wineListSize;
            wineItemArray = new WineItem[lengthOfArrayInt+(lengthOfArrayInt/2)];
        }

        #endregion



        #region Properties

        #endregion



        #region Private Methods

        private void ExpandArraySize()
        {

        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Loads Wine Items from file into Colletion Array.
        /// </summary>
        /// <param name="wineItem">The individual WineItem to add.</param>
        /// <param name="indexInt">Index the item will be added to.</param>
        public void LoadWineItem(WineItem wineItem, int indexInt)
        {
            wineItemArray[indexInt] = wineItem;
        }

        /// <summary>
        /// Displays contents of array in string format.
        /// </summary>
        /// <returns>String of array contents.</returns>
        public string GetCollectionToString()
        {
            string outputString = "";

            foreach (WineItem wineItem in wineItemArray)
            {
                if (wineItem != null)
                {
                    outputString += wineItem.ToString() + Environment.NewLine;
                }
            }

            if (outputString == "")
            {
                outputString = "Collection is currently empty.";
            }
            return outputString;
        }

        public void AddWineItem(WineItem wineItem)
        {
            if (lengthOfArrayInt < wineItemArray.Length)
            {
                wineItemArray[lengthOfArrayInt] = wineItem;
                lengthOfArrayInt++;
            }
            else
            {

            }
        }

        #endregion
    }
}

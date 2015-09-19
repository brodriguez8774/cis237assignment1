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
        private int wineListSizeInt;
        private int lenghtOfArrayInt;
        private int indexInt;

        private WineItem[] wineItemArray;
        private WineItem[] tempArray;

        #endregion



        #region Constructors

        /// <summary>
        /// Base Constructor.
        /// </summary>
        public WineItemCollection()
        {
            
        }

        /// <summary>
        /// Create Array Constructor with room for additional items.
        /// </summary>
        /// <param name="wineListSize">Size of wine List.</param>
        public WineItemCollection(int wineListSize)
        {
            WineListSize = wineListSize;

            lenghtOfArrayInt = wineListSizeInt + (wineListSizeInt / 2);
            wineItemArray = new WineItem[lenghtOfArrayInt];
        }

        #endregion



        #region Properties

        public int WineListSize
        {
            set
            {
                wineListSizeInt = value;
            }
            get
            {
                return wineListSizeInt;
            }
        }

        public WineItem[] WineItemArray
        {
            get
            {
                return wineItemArray;
            }
        }

        public int CurrentIndex
        {
            get
            {
                return indexInt;
            }
        }

        public int ArrayLength
        {
            get
            {
                return lenghtOfArrayInt;
            }
        }

        #endregion



        #region Private Methods

        /// <summary>
        /// Expands Collection if user fills up entire array. Generally only happens if manually creating a new list.
        /// </summary>
        private void ExpandArraySize()
        {
            lenghtOfArrayInt = wineListSizeInt + (wineListSizeInt / 2);
            tempArray = new WineItem[lenghtOfArrayInt];

            indexInt = 0;
            while (indexInt < wineListSizeInt)
            {
                tempArray[indexInt] = WineItemArray[indexInt];
                indexInt++;
            }
            wineItemArray = tempArray;
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

        /// <summary>
        /// Adds new WineItem to first availible spot in collection.
        /// </summary>
        /// <param name="wineItem"></param>
        public void AddWineItem(WineItem wineItem)
        {
            // Recursive if to account for no previous loaded list.
            if (wineListSizeInt < lenghtOfArrayInt)
            {
                if (wineItemArray[indexInt] == null)
                {
                    wineItemArray[indexInt] = wineItem;
                    wineListSizeInt++;
                    indexInt++;
                }
                else
                {
                    indexInt++;
                    AddWineItem(wineItem);
                }
            }
            else
            {
                ExpandArraySize();
            }
        }

        #endregion
    }
}

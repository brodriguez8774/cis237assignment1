using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    /// <summary>
    /// Stores and handles full collection of Wine Items.
    /// </summary>
    class WineItemCollection
    {
        #region Variables

        // Classes
        WineItem wineItem;

        // Input Variables
        private int loadListSizeInt;
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
        /// <param name="loadListSize">Size of wine List.</param>
        public WineItemCollection(int loadListSize)
        {
            LoadListSize = loadListSize;

            wineListSizeInt = 0;
            lenghtOfArrayInt = loadListSizeInt + (loadListSizeInt / 2);
            wineItemArray = new WineItem[lenghtOfArrayInt];
        }

        #endregion



        #region Properties

        public int LoadListSize
        {
            set
            {
                this.loadListSizeInt = value;
            }
        }
        public int WineListSize
        {
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
        /// Expands Collection if user fills up entire array.
        /// </summary>
        private void ExpandArraySize()
        {
            lenghtOfArrayInt = wineListSizeInt + (wineListSizeInt / 2);
            tempArray = new WineItem[lenghtOfArrayInt];

            indexInt = 0;
            while (indexInt < wineListSizeInt)
            {
                if (wineItemArray[indexInt] == null)
                {
                    indexInt = wineListSizeInt;
                }
                else
                {
                    tempArray[indexInt] = WineItemArray[indexInt];
                    indexInt++;
                }
            }
            wineItemArray = tempArray;
        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Loads Wine Items from file into Colletion Array.
        /// </summary>
        /// <param name="wineItem">The individual WineItem to add.</param>
        /// <param name="index">Index the item will be added to.</param>
        /// <param name="arrayEndSize">Total number of non-null items array will have.</param>
        public void LoadWineItem(WineItem wineItem, int index, int arrayEndSize)
        {
            wineListSizeInt = arrayEndSize;

            if (arrayEndSize < lenghtOfArrayInt)
            {
                wineItemArray[index] = wineItem;
            }
            else
            {
                ExpandArraySize();
                LoadWineItem(wineItem, index, arrayEndSize);
            }
        }

        /// <summary>
        /// Displays contents of array in string format.
        /// </summary>
        /// <returns>String of array contents.</returns>
        public string GetCollectionToString()
        {
            string outputString = "";

            indexInt = 0;
            foreach (WineItem wineItem in wineItemArray)
            {
                if (wineItem != null)
                {
                    indexInt++;
                    outputString += " " + (indexInt + ")").PadRight(6) + wineItem.ToString() + Environment.NewLine;
                }
            }
            return outputString;
        }

        /// <summary>
        /// Adds new WineItem to first available spot in collection.
        /// </summary>
        /// <param name="wineItem">Item to be added.</param>
        public void AddWineItem(WineItem wineItem)
        {
            // Test to see if there is room to add more items.
            if (wineListSizeInt < lenghtOfArrayInt)
            {
                // Recursive search for first empty index spot.
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
                AddWineItem(wineItem);
            }
        }

        /// <summary>
        /// Search for matching Wine ID.
        /// </summary>
        /// <param name="wineID">ID to search for.</param>
        /// <param name="index">Current index of search.</param>
        /// <returns>Full information of matching item.</returns>
        public WineItem SearchWineItem(string wineID, int index)
        {
            // Checks for end of array items.
            if (index < wineListSizeInt)
            {
                // Recursive search for match.
                if (wineItemArray[index].WineID == wineID)
                {
                    wineItem = wineItemArray[index];
                    index = wineListSizeInt;
                }
                else
                {
                    index++;
                    SearchWineItem(wineID, index);
                }
            }
            else
            {
                wineItem = new WineItem(wineID, "ID is Not Found", "ID is Not Found");
            }

            return wineItem;
        }

        /// <summary>
        /// Search for and removal of matching Wine ID.
        /// </summary>
        /// <param name="wineID">ID to search for.</param>
        /// <param name="index">Current index of search.</param>
        /// <returns>Information regarding item removal.</returns>
        public bool RemoveWineItem(string wineID, int index)
        {
            bool removedIDBool = false;
            
            // Checks for end of array.
            if (index < wineListSizeInt)
            {
                // If matching ID found.
                if (wineItemArray[index].WineID == wineID)
                {
                    int removalIndex = index;

                    indexInt = 0;
                    tempArray = new WineItem[wineListSizeInt + wineListSizeInt/2];
                    // Recreate array, minus index to remove.
                    while (indexInt < wineListSizeInt)
                    {
                        // Skip removalIndex.
                        if (indexInt == removalIndex)
                        {
                            indexInt++;
                        }
                        else
                        {
                            // If already passed removalIndex.
                            if (indexInt > removalIndex)
                            {
                                tempArray[indexInt - 1] = wineItemArray[indexInt];
                                indexInt++;
                            }
                            else
                            {
                                tempArray[indexInt] = wineItemArray[indexInt];
                                indexInt++;
                            }
                        }
                    }

                    wineItemArray = tempArray;
                    removedIDBool = true;
                    wineListSizeInt--;
                }
                else
                {
                    index++;
                    removedIDBool = RemoveWineItem(wineID, index);
                }
            }
            return removedIDBool;
        }

        #endregion
    }
}

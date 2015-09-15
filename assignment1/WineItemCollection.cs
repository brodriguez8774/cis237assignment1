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

        public WineItemCollection()
        {

        }

        public WineItemCollection(int wineListSize)
        {
            lengthOfArrayInt = wineListSize;
            wineItemArray = new WineItem[lengthOfArrayInt+(lengthOfArrayInt/2)];
        }

        #endregion



        #region Properties

        #endregion



        #region Methods

        public void AddWineItem(WineItem wineItem)
        {
            if (lengthOfArrayInt > wineItemArray.Length)
            {
                wineItemArray[lengthOfArrayInt] = wineItem;
                lengthOfArrayInt++;
            }
            else
            {

            }
        }

        public void LoadWineItem(WineItem wineItem, int indexInt)
        {
            wineItemArray[indexInt] = wineItem;
        }

        #endregion
    }
}

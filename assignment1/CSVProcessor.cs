using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace assignment1
{
    class CSVProcessor
    {
        #region Variables

        // Classes
        private WineItemCollection wineItemCollection;

        // Input Variables
        private int wineIDInt;
        private string wineDescriptionString;
        private string wineSizeString;

        // Working Variables
        private bool hasLoadedBool = false;
        private int wineListSizeInt;
        private int indexInt;

        private StreamReader inputFile;

        #endregion



        #region Constructors

        /// <summary>
        /// Base Constructor.
        /// </summary>
        public CSVProcessor()
        {
            GetListSize();
        }

        /// <summary>
        /// Constructor to read from file.
        /// </summary>
        /// <param name="wineItemCollection">The current instance of WineItemCollection Class.</param>
        public CSVProcessor(WineItemCollection wineItemCollection)
        {
            Collection = wineItemCollection;
        }

        #endregion



        #region Properties

        public WineItemCollection Collection
        {
            set
            {
                this.wineItemCollection = value;
            }
        }

        public int WineListSize
        {
            get
            {
                return wineListSizeInt;
            }
        }

        public int WineID
        {
            get
            {
                return wineIDInt;
            }
        }

        public string WineDescription
        {
            get
            {
                return wineDescriptionString;
            }
        }

        public string WineSize
        {
            get
            {
                return wineSizeString;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Deterimines size of items to handle.
        /// </summary>
        private void GetListSize()
        {
            while (inputFile.EndOfStream == false)
            {
                wineListSizeInt++;
            }
        }

        /// <summary>
        /// Reads from file to create WineItemCollection.
        /// </summary>
        public void ReadFile()
        {
            try
            {
                indexInt = 0;

                while (indexInt > wineListSizeInt)
                {
                    string inputString = inputFile.ReadLine();
                    var flds = inputString.Split(',');

                    WineItem wineItem = new WineItem();
                    wineItem.WineID = Convert.ToInt32(flds[0].Trim());
                    wineItem.WineDescription = flds[1].Trim();
                    wineItem.WineSize = flds[2].Trim();

                    wineItemCollection.LoadWineItem(wineItem, indexInt);

                    indexInt++;
                }
            }
            catch (Exception errmsg)
            {
                Console.WriteLine("ERROR" + Environment.NewLine + errmsg);
            }
        }

        #endregion
    }
}

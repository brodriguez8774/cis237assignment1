using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace assignment1
{
    /// <summary>
    /// Handles loading/reading of file.
    /// </summary>
    class CSVProcessor
    {
        #region Variables

        // Classes
        WineItem wineItem;
        WineItemCollection wineItemCollection;

        // Working Variables
        private static int loadListSizeInt;
        private int indexInt;

        private StreamReader inputFile;

        #endregion



        #region Constructors

        /// <summary>
        /// Base Constructor. Determines initial size of Loaded File. Needs to run prior to WineItemCollection creation.
        /// </summary>
        public CSVProcessor()
        {
            GetListSize();
        }

        /// <summary>
        /// Constructor to read from file.
        /// </summary>
        /// <param name="wineItemCollection">The current instance of WineItemCollection Class.</param>
        /// <param name="index">Index of first spot in array without a WineItem.</param>
        public CSVProcessor(WineItemCollection wineCollection, int index)
        {
            Collection = wineCollection;
            Index = index;

            ReadFile();
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

        public int Index
        {
            set
            {
                this.indexInt = value;
            }
        }

        public int LoadListSize
        {
            get
            {
                return loadListSizeInt;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Deterimines size of items to handle.
        /// </summary>
        private void GetListSize()
        {
            OpenFile();
            while (inputFile.EndOfStream == false)
            {
                inputFile.ReadLine();
                loadListSizeInt++;
            }
            CloseFile();
            
            // Forces wineList to at least be 10 items long. For future-proofing.
            if (loadListSizeInt < 10)
            {
                loadListSizeInt = 10;
            }
        }

        /// <summary>
        /// Opens file and sets to inputfile.
        /// </summary>
        private void OpenFile()
        {
            inputFile = File.OpenText("../../../datafiles/WineList.csv");
        }

        /// <summary>
        /// Closes inputFile.
        /// </summary>
        private void CloseFile()
        {
            inputFile.Close();
        }

        /// <summary>
        /// Reads from file to create WineItemCollection.
        /// </summary>
        private void ReadFile()
        {
            try
            {
                OpenFile();

                int arrayEndSizeInt = loadListSizeInt + wineItemCollection.WineListSize;

                while (indexInt < arrayEndSizeInt)
                {
                    string inputString = inputFile.ReadLine();
                    var flds = inputString.Split(',');

                    wineItem = new WineItem();
                    wineItem.WineID = flds[0].Trim();
                    wineItem.WineDescription = flds[1].Trim();
                    wineItem.WineSize = flds[2].Trim();

                    wineItemCollection.LoadWineItem(wineItem, indexInt, arrayEndSizeInt);

                    indexInt++;
                }
                CloseFile();
            }
            catch (Exception errmsg)
            {
                Console.WriteLine("ERROR" + Environment.NewLine + errmsg);
            }
        }


        #endregion

    }
}

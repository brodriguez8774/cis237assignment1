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
        private static bool hasLoadedBool;
        private static int wineListSizeInt;
        private int indexInt;

        private StreamReader inputFile;

        #endregion



        #region Constructors

        /// <summary>
        /// Base Constructor. Determines initial size of Loaded File.
        /// </summary>
        public CSVProcessor()
        {
            if (hasLoadedBool == false)
            {
                GetListSize();
                hasLoadedBool = true;
            }
            else
            {
                string errorDisplayString = "File already loaded.";
            }
        }

        /// <summary>
        /// Constructor to read from file.
        /// </summary>
        /// <param name="wineItemCollection">The current instance of WineItemCollection Class.</param>
        public CSVProcessor(WineItemCollection wineItemCollection)
        {
            Collection = wineItemCollection;
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



        #region Private Methods

        /// <summary>
        /// Deterimines size of items to handle.
        /// </summary>
        private void GetListSize()
        {
            OpenFile();
            while (inputFile.EndOfStream == false)
            {
                inputFile.ReadLine();
                wineListSizeInt++;
            }
            CloseFile();
        }


        private void OpenFile()
        {
            inputFile = File.OpenText("../../../datafiles/TestWineList.csv");
        }

        private void CloseFile()
        {
            inputFile.Close();
        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Reads from file to create WineItemCollection.
        /// </summary>
        private void ReadFile()
        {
            try
            {
                indexInt = 0;
                OpenFile();

                while (indexInt < wineListSizeInt)
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

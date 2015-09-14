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

        // Input Variables
        private int wineIDInt;
        private string wineDescriptionString;
        private string wineSizeString;

        // Working Variables
        private bool hasLoadedBool = false;
        private int wineListSizeInt;

        private StreamReader inputFile;

        #endregion



        #region Constructors

        public CSVProcessor()
        {

        }

        #endregion



        #region Properties

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

        private void ReadFile()
        {
            try
            {

                while (inputFile.EndOfStream == false)
                {


                    wineListSizeInt++;
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

using System;
using System.IO;

namespace PatientMonitor
{
    public class PatientDataReader
    {
        StreamReader dataFile;
        StreamReader dataFile1;
        StreamReader dataFile2;
        StreamReader dataFile3;
        StreamReader dataFile4;
        StreamReader dataFile5;
        StreamReader dataFile6;
        StreamReader dataFile7;
        StreamReader dataFile8;
        StreamReader dataFile9;

        /// <summary>
        /// Initializes a new unconnected instance.
        /// </summary>
        public PatientDataReader()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PMS.PatientDataReader"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public PatientDataReader(string fileName)
        {
            // Open the file
            dataFile = new StreamReader(fileName);
            // Discard the headings
            dataFile.ReadLine();
        }

        public void Connect(string fileName, string fileName1, string fileName2, string fileName3, string fileName4, string fileName5, string fileName6, string fileName7, string fileName8, string fileName9)
        {
            // Open the file
            dataFile = new StreamReader(fileName);
            dataFile1 = new StreamReader(fileName1);
            dataFile2 = new StreamReader(fileName2);
            dataFile3 = new StreamReader(fileName3);
            dataFile4 = new StreamReader(fileName4);
            dataFile5 = new StreamReader(fileName5);
            dataFile6 = new StreamReader(fileName6);
            dataFile7 = new StreamReader(fileName7);
            dataFile8 = new StreamReader(fileName8);
            dataFile9 = new StreamReader(fileName9);
            dataFile.ReadLine();
            dataFile1.ReadLine();
            dataFile2.ReadLine();
            dataFile3.ReadLine();
            dataFile4.ReadLine();
            dataFile5.ReadLine();
            dataFile6.ReadLine();
            dataFile7.ReadLine();
            dataFile8.ReadLine();
            dataFile9.ReadLine();
        }

        public string getData()
        {
            return dataFile.ReadLine();
        }
        public string getData1()
        {
            return dataFile1.ReadLine();
        }
        public string getData2()
        {
            return dataFile2.ReadLine();
        }
        public string getData3()
        {
            return dataFile3.ReadLine();
        }
        public string getData4()
        {
            return dataFile4.ReadLine();
        }
        public string getData5()
        {
            return dataFile5.ReadLine();
        }
        public string getData6()
        {
            return dataFile6.ReadLine();
        }
        public string getData7()
        {
            return dataFile7.ReadLine();
        }
        public string getData8()
        {
            return dataFile8.ReadLine();
        }
        public string getData9()
        {
            return dataFile9.ReadLine();
        }
    }
}
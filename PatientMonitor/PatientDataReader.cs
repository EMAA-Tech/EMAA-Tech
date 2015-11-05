using System;
using System.IO;

namespace PatientMonitor
{
	public class PatientDataReader
	{
		StreamReader dataFile;
        
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

        public void Connect(string fileName)
        {
            // Open the file
            dataFile = new StreamReader(fileName);
            // Discard the headings
            dataFile.ReadLine();
        }

		public string getData()
		{
			return dataFile.ReadLine();
		}
	}
}
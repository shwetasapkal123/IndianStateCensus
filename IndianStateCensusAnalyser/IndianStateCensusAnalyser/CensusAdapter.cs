using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class CensusAdapter
    {
        //Method to return census data from csv file 
        public string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            try
            {
                string[] censusData;
                if (Path.GetExtension(csvFilePath) != ".csv")
                    throw new CensusAnalyserException("Invalid file type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
                if (!File.Exists(csvFilePath))
                    throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
                censusData = File.ReadAllLines(csvFilePath);
                if (censusData[0] != dataHeaders)
                {
                    throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
                }
                return censusData;
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}

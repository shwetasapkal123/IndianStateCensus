using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusTest
{
    public class IndianStatesAnalyserTest
    {
        //UC1 File Path
        string stateCensusFilePath = @"C:\Users\user\Fellowship\IndianSensus\IndianStateCensusAnalyzer\IndianStateCensus";
        string wrongFilePath = @"C:\Users\user\Fellowship\IndianSensus\IndianStateCensusAnalyzer\IndianStateCensus";
        string wrongTypeFilePath = @"C:\Users\user\Fellowship\IndianSensus\IndianStateCensusAnalyzer\IndianStateCensus";
        string wrongDelimiterFilePath = @"C:\Users\user\Fellowship\IndianSensus\IndianStateCensusAnalyzer\IndianStateCensus";
        string wrongHeaderFilePath= @"C:\Users\user\Fellowship\IndianSensus\IndianStateCensusAnalyzer\IndianStateCensus";

        //UC2
        string statCodeFilePath = @"C:\Users\user\Fellowship\NewIndianCensusCode\IndianStateCensus\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndiaStateCode.csv";
        string wrongStateCodeFilePath = @"C:\Users\user\Fellowship\NewIndianCensusCode\IndianStateCensus\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        string wrongStateCodeTypeFilePath = @"C:\Users\user\Fellowship\NewIndianCensusCode\IndianStateCensus\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndiaStateCode.txt";
        string wrongStateCodeDelimiterFilePath = @"C:\Users\user\Fellowship\NewIndianCensusCode\IndianStateCensus\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\DelimeterIndiaStateCode.csv";
        string wrongStateCodeHeaderFilePath = @"C:\Users\user\Fellowship\NewIndianCensusCode\IndianStateCensus\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\WrongIndiaStateCode.csv";
        string stateCodeHeader = "SrNo,State Name,TIN,StateCode";

        //Objects for csv data files
        CSVAdapterFactory csvAdapter;
        Dictionary<string, CensusDTO> stateRecords;
        Dictionary<string, CensusDTO> stateCodeRecords;

        [TestInitialize]
        public void SetUp()
        {
            csvAdapter = new CSVAdapterFactory();
            stateRecords = new Dictionary<string, CensusDTO>();
            stateCodeRecords = new Dictionary<string, CensusDTO>();
        }
        //TC 1.1 Given correct path To ensure number of records matches
        [TestMethod]
        public void GivenStateCensusCsvReturnStateRecords()
        {
            int expected = 29;
            stateRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusFilePath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(expected, stateRecords.Count);
        }

        //TC 1.2 Given incorrect file should return custom exception - File not found
        [TestMethod]
        public void GivenWrongFileReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.3 Given correct path but incorrect file type should return custom exception - Invalid file type
        [TestMethod]
        public void GivenWrongFileTypeReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
        [TestMethod]
        public void GivenWrongDelimiterReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.5 Given correct path but wrong header should return custom exception - Incorrect header in Data
        [TestMethod]
        public void GivenWrongHeaderReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.1 Given correct path To ensure number of records matches
        [TestMethod]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesCsvReturnStateRecords()
        {
            int expected = 37;
            stateCodeRecords = csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, statCodeFilePath, stateCodeHeader);
            Assert.AreEqual(expected, stateCodeRecords.Count);
        }

        //TC 2.2 Given incorrect file should return custom exception - File not found
        [TestMethod]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesWrongFileReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.3 Given correct path but incorrect file type should return custom exception - Invalid file type
        [TestMethod]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesWrongFileTypeReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeTypeFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
        [TestMethod]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesWrongDelimiterReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeDelimiterFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 2.5 Given correct path but wrong header should return custom exception - Incorrect header in Data
        [TestMethod]
        [TestCategory("Indian State Codes")]
        public void GivenStateCodesWrongHeaderReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeHeaderFilePath, stateCodeHeader));
            Assert.AreEqual(expected, customException.exception);
        }


    }
}

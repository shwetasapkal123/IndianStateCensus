using IndianStateCensusAnalyser.DataDAO;
using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        // Dictionary<string, StateCodeDataDAO> datamap;
        Dictionary<string, CensusDTO> censusState;
        //Dictionary<string, CensusDTO> datamap;

        //Method to load csv file return in the form of dictionary
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            try
            {
                //datamap = new Dictionary<string, StateCodeDataDAO>();
                censusState = new Dictionary<string, CensusDTO>();
                censusData = GetCensusData(csvFilePath, dataHeaders);
                foreach (string data in censusData.Skip(1))
                {
                    if (!data.Contains(","))
                    {
                        throw new CensusAnalyserException("File Containers Wrong Delimiter", CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
                    }
                    string[] coloumn = data.Split(',');
                    if (csvFilePath.Contains("IndiaStateCode.csv"))
                        censusState.Add(coloumn[0], new CensusDTO(new StateCodeDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
                    if (csvFilePath.Contains("IndianPopulation.csv"))
                        censusState.Add(coloumn[0], new CensusDTO(new PopulationDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
                }
                return censusState;
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}

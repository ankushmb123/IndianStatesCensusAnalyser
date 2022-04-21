using IndianStatesCensusAnalyser;
using NUnit.Framework;
using System.Collections.Generic;

namespace CensusAnalyserTest
{
    public class UnitTests
    {

        static string indianStateCensusHeaders = @"State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = @"SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\User\@nkush\Day 29\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\User\@nkush\Day 29\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        static string delimeterIndianCensusFilePath = @"C:\User\@nkush\Day 29\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\DelimeterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\User\@nkush\Day 29\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianCensusFileType = @"C:\User\@nkush\Day 29\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";

       
        IndianStatesCensusAnalyser.CensusAnalyzer censusAnalyzer;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        
        public object Country { get; private set; }

        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyzer();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        //Use case - 1
        //Happy Test Case 1.1 : the records are checked
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            System.Console.WriteLine("Indian state records Count : " + totalRecord.Count);
            Assert.AreEqual(29, totalRecord.Count);
        }

        //Sad Test Case 1.2 : to verify if the exception is raised.
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(37, totalRecord.Count);
        }

        //Sad Test Case 1.3 : if the type is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileTypeWrong_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, wrongIndianCensusFileType, indianStateCensusHeaders);

            Assert.AreEqual(29, totalRecord.Count);
        }

        //Sad Test Case 1.4 : if the file delimiter is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileDelimeterWrong_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, delimeterIndianCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        //Sad Test Case 1.5 : if the header is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileCsvHeaderWrong_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, wrongHeaderIndianCensusFilePath);
            Assert.AreEqual(29, totalRecord.Count);
        }
    }
}




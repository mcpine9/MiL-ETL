using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using CsvHelper;
using IngramDataConnect.ETL.Utility;

namespace IngramDataConnect.ETL
{
    class DataTableCsvReader : IDataTableCSVReader
    {
        public DataTable DataTableResult { get; set; }
        public string ErrorMessage { get; private set; }

        public void ReadIntoTable(string path)
        {
            var exceptions = new List<string>();
            var rowList = new List<string[]>();
            DataTableResult = new DataTable("Mil_Titles");
            try
            {
                var textReader = new StreamReader(path);
                using (textReader)
                {
                    using (var csvReader = new CsvReader(textReader))
                    {
                        try
                        {
                            csvReader.Configuration.Delimiter = ConfigurationManager.AppSettings["FileDelimiter"];
                            //csvReader.Configuration.IgnoreReadingExceptions = true;
                            csvReader.Configuration.RegisterClassMap<MilTitlesMap>();
                            csvReader.Configuration.ReadingExceptionCallback = (ex, row) =>
                            {
                                exceptions.Add(ex.Message + " " + ex.StackTrace);
                                rowList.Add(row.CurrentRecord);
                            };
                            var records = csvReader.GetRecords<MiLTitles>().ToList();   
                            DataTableResult = records.ConvertToDatatable();
                        }
                        catch (Exception ex)
                        {
                            var exception = ex.Data["CsvHelper"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                DataTableResult = null;
                ErrorMessage = "There was an error inside CsvReader: " + e.Message;
                throw new Exception(e.Message);
            }
        }
    }
}
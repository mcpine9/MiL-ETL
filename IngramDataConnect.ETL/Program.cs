using System;
using System.Data;
using IngramDataConnect.ETL.Utility;
using StructureMap;
using StructureMap.Graph;

namespace IngramDataConnect.ETL
{
    class Program
    {
        static void Main(string[] args)
        {
            bool failure = false;
            InitIoC();
            var dt = ObjectFactory.GetInstance<IProvideDataTable>();
            Console.WriteLine("...Initialized.");
            Console.Write("Enter path to csv: ");
            string input = Console.ReadLine();
            dt.GetDataTable(input);
            while (dt.ReadFail)
            {
                Console.WriteLine(dt.StatusMessage);
                Console.Write("Enter path to csv: ");
                input = Console.ReadLine();
                dt.GetDataTable(input);
            }

            if (dt.PopulatedDataTable != null)
            {   
                BulkCopyToDB.BulkCopyDataTableToTempTable(dt.PopulatedDataTable, ref failure);
            }
            else
            {
                Console.WriteLine(dt.StatusMessage);
                failure = true;
            }
            if (failure)
            {
                Console.ReadLine();
                Environment.Exit(0);
            }
            Console.WriteLine("Success!");
            Console.ReadLine();

        }

        private static void InitIoC()
        {
            ObjectFactory.Configure(config =>
            {
                config.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

                config.For<IReadFile>().Use<ReadCSVFile>();
                config.For<IProvideDataTable>().Use<ProvideDataTableFromCSV>();
                config.For<IDataTableCSVReader>().Use<DataTableCsvReader>();

            });
        }
    }
}

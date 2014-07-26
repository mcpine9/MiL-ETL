using System;
using System.Data;

namespace IngramDataConnect.ETL
{
    public class ProvideDataTableFromCSV : IProvideDataTable
    {
        public DataTable PopulatedDataTable { get; set; }
        public bool ReadFail { get; set; }
        public string StatusMessage { get; set; }
        private IReadFile _file { get; set; }
        private IDataTableCSVReader _reader { get; set; }


        public ProvideDataTableFromCSV(IReadFile file, IDataTableCSVReader reader)
        {
            _file = file;
            _reader = reader;
        }
            
        public void GetDataTable(string path)
        {
                try
                {
                    _file.ReadFile(path);
                    if (_file.IsSuccessfullRead)
                    {
                        _reader.ReadIntoTable(path);
                        if (_reader.DataTableResult != null)
                        {
                            PopulatedDataTable = _reader.DataTableResult;
                        }
                    }
                    else
                    {
                        ReadFail = true;
                        if (!_file.IsValidFileType)
                        {
                            StatusMessage = _file.InvalidFileTypeMessage;
                        }
                        else if (!_file.IsValidPath)
                        {
                            StatusMessage = _file.InvalidPathMessage;
                        }
                        else
                        {
                            StatusMessage = _file.ErrorReadingMessage;
                        }
                    }
                }
                catch (Exception e)
                {
                    PopulatedDataTable = null;
                    StatusMessage = "There was an error inside GetDataTable:" + e.Message;
                }
        }
    }
}
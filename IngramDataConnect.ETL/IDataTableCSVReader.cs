using System.Data;

namespace IngramDataConnect.ETL
{
    public interface IDataTableCSVReader
    {
        DataTable DataTableResult { get; set; }
        void ReadIntoTable(string path);
    }
}
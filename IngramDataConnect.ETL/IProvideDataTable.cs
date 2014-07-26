using System.Data;

namespace IngramDataConnect.ETL
{
    public interface IProvideDataTable
    {
        DataTable PopulatedDataTable { get; set; }
        bool ReadFail { get; set; }
        string StatusMessage { get; set; }
        void GetDataTable(string path);
    }
}
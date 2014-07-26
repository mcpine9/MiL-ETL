namespace IngramDataConnect.ETL
{
    public interface IProcessFile
    {
        dynamic Process(string path);
    }
}

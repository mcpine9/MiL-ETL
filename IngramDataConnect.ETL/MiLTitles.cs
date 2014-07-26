using System;

namespace IngramDataConnect.ETL
{
    public class MiLTitles
    {
        public long Title_ID { get; set; }
        public string ISBN { get; set; }
        public string EISBN { get; set; }
        public string EPubISBN { get; set; }
        public string HISBN { get; set; }
        public string PISBN { get; set; }
        public string MILISBN { get; set; }
        public string Display_Title { get; set; }
        public string Series { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Subjects { get; set; }
        public string Authors { get; set; }
        public string Editors { get; set; }
        public string Publisher { get; set; }
        public string Imprint { get; set; }
        public string Publish_Date { get; set; }
        public string Publish_Year { get; set; }
        public string CopyrightDate { get; set; }
        public string Publish_Data { get; set; }
        public string Abstract { get; set; }
        public DateTime Date_Added { get; set; }
        public long? Organization_ID { get; set; }
        public string First_Page { get; set; }
        public int Num_Pages { get; set; }
        public DateTime Build_Date { get; set; }
        public string Type { get; set; }
        public string Region { get; set; }
        public string Retail_Price { get; set; }
        public string DiscountCode { get; set; }
        public string LCControl { get; set; }
        public string NLM_Class { get; set; }
        public string Marc_LCClass { get; set; }
        public string Marc_Dewey { get; set; }
        public string Marc_Title { get; set; }
        public string Marc_Author { get; set; }
        public string Marc_Subtitle { get; set; }
        public string Marc_Publisher { get; set; }
        public string Marc_PubData { get; set; }
        public string Marc_Subjects { get; set; }
        public string BICC_Subject { get; set; }
        public string Edition { get; set; }
        public string Readership { get; set; }
        public string Organization_Category { get; set; }
        public int Visible { get; set; }
        public string MESH_Subject_Headings { get; set; }
        public long LC_ID { get; set; }
        public long Language_ID { get; set; }
        public bool CreateMARCRecord { get; set; }
        public DateTime DateTimeUpdated { get; set; }
        public bool Downloadable { get; set; }
        public long BisacSubjectID { get; set; }
        public string BisacSubjects { get; set; }
        public string BisacCode { get; set; }
        public bool AllowAccessModel { get; set; }
        public bool AllowILL { get; set; }
        public string Notes { get; set; }
        public bool Export_Record  { get; set; }
    }
}

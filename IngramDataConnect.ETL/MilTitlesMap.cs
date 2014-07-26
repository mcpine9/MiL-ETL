using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using IngramDataConnect.ETL.Utility;

namespace IngramDataConnect.ETL
{
    public sealed class MilTitlesMap : CsvClassMap<MiLTitles>
    {
        public MilTitlesMap()
        {
            Map(m => m.Title_ID).ConvertUsing(row =>
            {
                long intField;
                if (!row.TryGetField(0, out intField))
                {
                    return Convert.ToInt64(row.CurrentRecord[0]);
                }
                return row.GetField<long>(0);
            });
            Map(m => m.ISBN);
            Map(m => m.EISBN);
            Map(m => m.EPubISBN);
            Map(m => m.HISBN);
            Map(m => m.PISBN);
            Map(m => m.MILISBN);
            Map(m => m.Display_Title).ConvertUsing(row => row.GetField(7).Replace("null", ""));
            Map(m => m.Series);
            Map(m => m.Title);
            Map(m => m.SubTitle);
            Map(m => m.Subjects);
            Map(m => m.Authors);
            Map(m => m.Editors);
            Map(m => m.Publisher);
            Map(m => m.Imprint);
            Map(m => m.Publish_Date);
            Map(m => m.Publish_Year);
            Map(m => m.CopyrightDate);
            Map(m => m.Publish_Data);
            Map(m => m.Abstract);
            Map(m => m.Date_Added)
                .ConvertUsing(row =>
                {
                    if (String.IsNullOrEmpty(row.GetField("Date_Added")))
                    {
                        return DateTime.Parse("01/01/1900");
                    }
                    return row.GetField<DateTime>("Date_Added");
                });
            Map(m => m.Organization_ID).Index(22).Default(default(int));
            Map(m => m.First_Page);
            Map(m => m.Num_Pages).ConvertUsing(x => x.GetRecord<int>());
            Map(m => m.Build_Date)
                .ConvertUsing(row =>
                {
                    if (String.IsNullOrEmpty(row.GetField("Build_Date")))
                    {
                        return DateTime.Parse("01/01/1900");
                    }
                    return row.GetField<DateTime>("Build_Date");
                });
            Map(m => m.Type);
            Map(m => m.Region);
            Map(m => m.Retail_Price);
            Map(m => m.DiscountCode);
            Map(m => m.LCControl);
            Map(m => m.NLM_Class);
            Map(m => m.Marc_LCClass);
            Map(m => m.Marc_Dewey);
            Map(m => m.Marc_Title);
            Map(m => m.Marc_Author);
            Map(m => m.Marc_Subtitle);
            Map(m => m.Marc_Publisher);
            Map(m => m.Marc_PubData);
            Map(m => m.Marc_Subjects);
            Map(m => m.BICC_Subject);
            Map(m => m.Edition);
            Map(m => m.Readership);
            Map(m => m.Organization_Category);
            Map(m => m.Visible).ConvertUsing(x => x.GetRecord<int>());
            Map(m => m.MESH_Subject_Headings);
            Map(m => m.LC_ID).ConvertUsing(x => x.GetRecord<int>());
            Map(m => m.Language_ID).ConvertUsing(x => x.GetRecord<int>());
            Map(m => m.CreateMARCRecord).ConvertUsing(x => x.GetRecord<bool>());
            Map(m => m.DateTimeUpdated)
                .ConvertUsing(row =>
                {
                    if (String.IsNullOrEmpty(row.GetField("DateTimeUpdated")))
                    {
                        return DateTime.Parse("01/01/1900");
                    }
                    return row.GetField<DateTime>("DateTimeUpdated");
                });
            Map(m => m.Downloadable).ConvertUsing(x => x.GetRecord<bool>());
            Map(m => m.BisacSubjectID).ConvertUsing(x => x.GetRecord<int>());
            Map(m => m.BisacSubjects);
            Map(m => m.BisacCode);
            Map(m => m.AllowAccessModel).ConvertUsing(x => x.GetRecord<bool>());
            Map(m => m.AllowILL).ConvertUsing(x => x.GetRecord<bool>());
            Map(m => m.Notes);
            Map(m => m.Export_Record).ConvertUsing(x => x.GetRecord<bool>());
        }
    }
}

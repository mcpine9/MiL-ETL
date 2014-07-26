using System;
using CsvHelper.TypeConversion;

namespace IngramDataConnect.ETL.Utility
{
    class DoubleToIntConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(TypeConverterOptions options, string text)
        {
            if (text == null)
            {
                return default(int);
            }

            double doubleValue = Convert.ToDouble(text);
            int intValue = Convert.ToInt32(doubleValue);

            return intValue;
        }
    }
}

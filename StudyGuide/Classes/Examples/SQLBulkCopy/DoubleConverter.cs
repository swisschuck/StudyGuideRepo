using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace StudyGuide.Classes.Examples.SQLBulkCopy
{
    public class DoubleConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.Compare(text, "NONE", true) == 0)
            {
                return null;
            }
            else
            {
                return double.Parse(text);
            }
        }
    }
}

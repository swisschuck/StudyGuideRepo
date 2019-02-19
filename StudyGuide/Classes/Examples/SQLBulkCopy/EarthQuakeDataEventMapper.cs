using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.SQLBulkCopy
{
    //Sealed classes are used to restrict the inheritance feature of object oriented programming. 
    // Once a class is defined as a sealed class, this class cannot be inherited.

    public sealed class EarthQuakeDataEventMapper : ClassMap<EarthQuakeData>
    {
        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region constructors
        public EarthQuakeDataEventMapper()
        {
            int i = 0;

            Map(m => m.OGSEventID).Index(i++);

            Map(m => m.OriginTime).Index(i++);

            Map(m => m.Magnitude).Index(i++).TypeConverter<DoubleConverter>();

            Map(m => m.MagnitudeSource).Index(i++);

            Map(m => m.MaxMMI).Index(i++).TypeConverter<DoubleConverter>(); ;

            Map(m => m.Latitude).Index(i++).TypeConverter<DoubleConverter>(); ;

            Map(m => m.Longitude).Index(i++).TypeConverter<DoubleConverter>(); ;

            Map(m => m.DepthKm).Index(i++).TypeConverter<DoubleConverter>(); ;

            Map(m => m.ErrorLatitude).Index(i++).TypeConverter<DoubleConverter>(); ;

            Map(m => m.ErrorLongitude).Index(i++).TypeConverter<DoubleConverter>(); ;

            Map(m => m.ErrorDepth).Index(i++).TypeConverter<DoubleConverter>(); ;

            Map(m => m.ErrorOriginTime).Index(i++).TypeConverter<DoubleConverter>(); ;

            Map(m => m.State).Index(i++);

            Map(m => m.County).Index(i++);

            Map(m => m.Status).Index(i++);
        }

        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

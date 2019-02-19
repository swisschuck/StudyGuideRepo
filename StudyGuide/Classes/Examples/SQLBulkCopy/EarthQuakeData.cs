using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.SQLBulkCopy
{
    public class EarthQuakeData
    {
        #region fields
        #endregion fields


        #region properties

        public int? OGSEventID { get; set; }
        public DateTime? OriginTime { get; set; }
        public double? Magnitude { get; set; }
        public string MagnitudeSource { get; set; }
        public double? MaxMMI { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? DepthKm { get; set; }
        public double? ErrorLatitude { get; set; }
        public double? ErrorLongitude { get; set; }
        public double? ErrorDepth { get; set; }
        public double? ErrorOriginTime { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string Status { get; set; }

        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIStudyGuide.Models.Other
{
    // DTO = Data Transfer Object
    public class CityDto
    {
        #region fields
        #endregion fields


        #region properties

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfPointsOfInterest {

            get
            {
                return PointsOfInterest.Count;
            }
        }

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();

        #endregion properties


        #region constructors

        public CityDto()
        {

        }

        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestAPIStudyGuide.EntityFramework.Context.Other;
using RestAPIStudyGuide.EntityFramework.Entities.Other;
using RestAPIStudyGuide.Models.Other;

namespace RestAPIStudyGuide.Services.Other
{
    public class CityInfoRepository : ICityInfoRepository
    {
        // this class will be used to provide persistance logic
        #region fields

        private CityInfoDBContext _cityInfoDBContext;

        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public CityInfoRepository(CityInfoDBContext context)
        {
            _cityInfoDBContext = context;
        }

        #endregion constructors


        #region public methods

        public IEnumerable<CityDto> GetCities()
        {
            return _cityInfoDBContext.Cities.OrderBy(c => c.Name).ToList();
        }

        public CityDto GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                // the include extension method is part of the entity framework core namespace
                // from MS site: "Specifies the related objects to include in the query results." <-- fuck you and your shitty explanations microsoft!
                return _cityInfoDBContext.Cities.Include(c => c.PointsOfInterest)
                                                .Where(c => c.Id == cityId).FirstOrDefault();
            }
            else
            {
                return _cityInfoDBContext.Cities.Where(c => c.Id == cityId).FirstOrDefault();
            }

        }

        public PointOfInterestDto GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return _cityInfoDBContext.PointsOfInterest.Where(p => p.Id == pointOfInterestId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterestDto> GetPointsOfInterestForCity(int cityId)
        {
            return _cityInfoDBContext.PointsOfInterest.Where(p => p.Id == cityId).ToList();
        }

        public bool CityExists(int cityId)
        {
            return _cityInfoDBContext.Cities.Any(city => city.Id == cityId);
        }

        //public void AddPointOfInterestForCity(int cityId, PointOfInterestDto pointOfInterest)
        //{
        //    var city = GetCity(cityId, false);
        //    city.PointsOfInterest.Add(pointOfInterest);
        //}

        //public bool Save()
        //{
        //    return (_cityInfoDBContext.SaveChanges() >= 0);
        //}

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

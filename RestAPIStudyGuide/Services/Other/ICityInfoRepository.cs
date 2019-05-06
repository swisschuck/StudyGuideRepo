using RestAPIStudyGuide.Models.Other;
using System.Collections.Generic;

namespace RestAPIStudyGuide.Services.Other
{
    public interface ICityInfoRepository
    {
        IEnumerable<CityDto> GetCities();

        CityDto GetCity(int cityId, bool includePointsOfInterest);

        IEnumerable<PointOfInterestDto> GetPointsOfInterestForCity(int cityId);

        PointOfInterestDto GetPointOfInterestForCity(int cityId, int pointOfInterestId);

        bool CityExists(int cityId);

        //void AddPointOfInterestForCity(int cityId, PointOfInterestDto pointOfInterest);

        //bool Save();
    }
}

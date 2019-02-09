using Microsoft.AspNetCore.Mvc;
using RestAPIStudyGuide.DataStore.Other;
using RestAPIStudyGuide.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIStudyGuide.Controllers.Other
{
    [Route("api/cities")] // we could make a seperate tunnel into the API that could look something like [Route("api/pointsOfInterest")] but we want
                         // the data and API structure to match. Since PointsOfInterest is a child model of the CityDto we will have the user drill down
                         // through the cities controller then use this controller to carry out pointOfInterest calls.
    public class PointsOfInterestController : Controller
    {
        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public PointsOfInterestController()
        {

        }

        #endregion constructors


        #region public methods

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city.PointsOfInterest);
        }


        [HttpGet("{cityId}/pointsofinterest/{id}")]
        // an important note, the parameter placeholder in the HttpGet route defined above needs to match exactly with the parameter name defined in
        // actual method signature.
        public IActionResult GetPointOfInterest(int cityId, int id) 
        {
            CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            PointOfInterestDto pointOfInterest = city.PointsOfInterest.FirstOrDefault(poi => poi.Id == id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

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

        // here we can use the Name = parameter of this method attribute to give this method a name, this name can then be used as a reference in some of our
        // create responses.
        [HttpPost("{cityId}/pointsofinterest", Name = "GetPointOfInterestReferenceName")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            // [FromBody]  - allows us to get the content of the request. The request body will contain the information needed
            // to create a new point of interest. We want to serialize this point of interest dto.


            // because we are expecting a well formed PointOfInterestForCreationDto json object to be passed in we need to do some validation first
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            // make sure he city exists
            CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            // get the last POI ID so we can create the new one
            int lastPointOfInterestID = CitiesDataStore.Current.Cities.SelectMany(c => city.PointsOfInterest).Max(p => p.Id);

            // map the POI for creation object to a DTO that we will use
            PointOfInterestDto newPointOfInterestDto = new PointOfInterestDto()
            { 
                Id = ++lastPointOfInterestID,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(newPointOfInterestDto);

            // for posts, its recommended to return a 201 Created response, we can return this using a the built in helper methods.
            // This helper response method will allow us to add a location header to the response, this will contain the new location URI where
            // the newly created information can be found.
            return CreatedAtRoute("GetPointOfInterestReferenceName", new { cityId = cityId, id = newPointOfInterestDto.Id} , newPointOfInterestDto);
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

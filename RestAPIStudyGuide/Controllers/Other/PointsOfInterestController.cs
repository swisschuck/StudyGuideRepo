using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestAPIStudyGuide.DataStore.Other;
using RestAPIStudyGuide.Models.Other;
using System.Linq;
using Microsoft.Extensions.Logging;
using System;
using RestAPIStudyGuide.Services.Other;
using System.Collections.Generic;

namespace RestAPIStudyGuide.Controllers.Other
{
    [Route("api/cities")] // we could make a seperate tunnel into the API that could look something like [Route("api/pointsOfInterest")] but we want
                         // the data and API structure to match. Since PointsOfInterest is a child model of the CityDto we will have the user drill down
                         // through the cities controller then use this controller to carry out pointOfInterest calls.
    public class PointsOfInterestController : Controller
    {
        #region fields

        private ILogger<PointsOfInterestController> _logger;
        private IMailService _mailService;
        private ICityInfoRepository _cityInfoRepository;
        #endregion fields


        #region properties
        #endregion properties


        #region constructors


        // here we are injecting a dependancy into this controller of some form of ILogger
        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, IMailService mailService, ICityInfoRepository cityInfoRepository)
        {
            _logger = logger;
            _mailService = mailService;
            _cityInfoRepository = cityInfoRepository;
        }

        #endregion constructors


        #region public methods

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            try
            {
                if (!_cityInfoRepository.CityExists(cityId))
                {
                    _logger.LogInformation($"City with id {cityId} wasnt found when accessing points of interest.");
                    return NotFound();
                }

                //CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

                //if (city == null)
                //{
                //    _logger.LogInformation($"City with id {cityId} wasnt found when accessing points of interest.");
                //    return NotFound();
                //}

                IEnumerable<PointOfInterestDto> pointsOfInterest = _cityInfoRepository.GetPointsOfInterestForCity(cityId);

                List<PointOfInterestDto> results = new List<PointOfInterestDto>();

                foreach (PointOfInterestDto poi in pointsOfInterest)
                {
                    results.Add(new PointOfInterestDto()
                    {
                        Id = poi.Id,
                        Name = poi.Name,
                        Description = poi.Description
                    });
                }

                return Ok(results);
            }
            catch (Exception ex)
            {
                // all exceptions should be of Critical status.
                _logger.LogCritical($"Exception while getting points of interest for city with id {cityId}.", ex);

                // we know that unhandled exceptions will return a 500 status code request by default so we need to define the status code to be
                // returned manually, this way we can provide the consumer of the API a message. Be careful what you send back to the client as too
                // much details can provide a way for hackers to figure out whats happening with your API.
                return StatusCode(500, "A problem happened while handling your request :-(");
            }

        }

        // here we can use the Name = parameter of this method attribute to give this method a name, this name can then be used as a reference in some of our
        // create responses.
        [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterestReferenceName")]
        // an important note, the parameter placeholder in the HttpGet route defined above needs to match exactly with the parameter name defined in
        // actual method signature.
        public IActionResult GetPointOfInterest(int cityId, int id) 
        {

            if (!_cityInfoRepository.CityExists(cityId))
            {
                _logger.LogInformation($"City with id {cityId} wasnt found when accessing points of interest.");
                return NotFound();
            }

            PointOfInterestDto poi = _cityInfoRepository.GetPointOfInterestForCity(cityId, id);

            if (poi == null)
            {
                return NotFound();
            }

            PointOfInterestDto result = new PointOfInterestDto()
            {
                Id = poi.Id,
                Name = poi.Name,
                Description = poi.Description
            };

            return Ok(result);
        }


        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            // [FromBody]  - allows us to get the content of the request. The request body will contain the information needed
            // to create a new point of interest. We want to serialize this point of interest dto.


            // because we are expecting a well formed PointOfInterestForCreationDto json object to be passed in we need to do some validation first
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            //validate the incoming PointOfInterestForCreationDto has valid properties


            // we can of course create our own validation on the object like so:

            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different than the name.");
            }

            if (!ModelState.IsValid)
            {
                //return BadRequest(); // if we just want to return a bad request then we can just use this

                return BadRequest(ModelState); // if we want to include the property error messages (in the response body) that are defined on the
                                               // PointOfInterestForCreationDto model then we need to include the model state.
            }


            // make sure the city exists
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

        [HttpPut("{cityId}/pointsofinterest/{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id, [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different than the name.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            PointOfInterestDto pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            pointOfInterestFromStore.Name = pointOfInterest.Name;
            pointOfInterestFromStore.Description = pointOfInterest.Description;

            return NoContent(); // the request complete succesfully but there is nothing to return. The user sent in the content that needed to be
                                // changed so we dont need to return the updated object to them.
        }


        [HttpPatch("{cityId}/pointsofinterest/{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id, [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        {
            // first lets check to make sure the patch document is ok
            if (patchDocument == null)
            {
                return BadRequest();
            }

            // now we run our normal validation checks
            CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            PointOfInterestDto pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            PointOfInterestForUpdateDto pointOfInterestToPatch =
                new PointOfInterestForUpdateDto()
                {
                    Name = pointOfInterestFromStore.Name,
                    Description = pointOfInterestFromStore.Description
                };

            // here we are applying the incoming patch document to our update dto object to see if it passes the requirements
            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);
            
            // check the model state after the patch document has been applied to see if it passes.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // check our custom validation rule
            if (pointOfInterestToPatch.Description == pointOfInterestToPatch.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different than the name.");
            }

            // now we are going to use a built in validation helper to check the model itself for its validation.
            TryValidateModel(pointOfInterestToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }


        [HttpDelete("{cityId}/pointsofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            PointOfInterestDto pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            city.PointsOfInterest.Remove(pointOfInterestFromStore);

            _mailService.Send("A point of interest was deleted.", $"Point of interest {pointOfInterestFromStore.Name} with id {pointOfInterestFromStore.Id} was deleted.");

            return NoContent();
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

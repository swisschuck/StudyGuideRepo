using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestAPIStudyGuide.DataStore.Other;

namespace RestAPIStudyGuide.Controllers.Other
{
    // here we are defining the prefix for the controller class name, any requests that come in prefixed with api/cites will get routed to this controller.
    [Route("api/cities")]

    //[Route("api/[controller]")] // we can also use this approach but its not great. If we were to refractor this controller class with a new name, it would break here.
    // this can be considered an advantage for web applications but not so much for API's
    public class CitiesController : Controller
    {
        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public CitiesController()
        {

        }

        #endregion constructors


        #region public methods

        [HttpGet()]
        public IActionResult GetCities()
        {
            //JsonResult jsonResult = new JsonResult(CitiesDataStore.Current.Cities);
            //jsonResult.StatusCode = 200; // so we can manually return our own custom status codes or we can make use of the built in status code helper
            //                             // methods that are built into .NET core.
            //return Ok(jsonResult);
            ////return jsonResult;

            return Ok(CitiesDataStore.Current.Cities);
        }


        [HttpGet("{id}")]
        //[HttpGet("api/cities/{id}")] // because we have the class routing prefix at the top we dont have to fully declare the route here,
        //                                just the parameters.
        public IActionResult GetCity(int id)
        {
            JsonResult cityToReturn = new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == id));

            if (cityToReturn == null || cityToReturn.Value == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
        }

        #endregion public methods


        #region private methods
        #endregion private methods








        #region Reference Code

        // so we can just send back the JsonResult but its better to use 
        //[HttpGet()]
        //public JsonResult GetCities()
        //{
        //    JsonResult jsonResult = new JsonResult(CitiesDataStore.Current.Cities);
        //    jsonResult.StatusCode = 200;
        //    return jsonResult;
        //}

        #endregion Reference Code
    }
}


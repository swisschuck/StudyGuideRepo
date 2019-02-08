using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestAPIStudyGuide.Controllers
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
        public JsonResult GetCities()
        {
            return new JsonResult(new List<object>()
            {
                new { id=1, Name="Denver" },
                new { id=2, Name="New York" }
            });
        }
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

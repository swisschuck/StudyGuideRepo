using Microsoft.AspNetCore.Mvc;
using RestAPIStudyGuide.EntityFramework.Context.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIStudyGuide.Controllers.Other
{
    public class DummyController : Controller
    {
        // this dummy controller is/was just used for testing things like:
        // - SQL server connetions
        #region fields

        private CityInfoDBContext _cityInfoDBContext;

        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public DummyController(CityInfoDBContext context)
        {
            _cityInfoDBContext = context;
        }

        #endregion constructors


        #region public methods

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }


        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

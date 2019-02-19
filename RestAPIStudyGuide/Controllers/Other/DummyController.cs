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
        // - SQL server connections
        #region fields

        private CityInfoDBContext _cityInfoDBContext;

        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public DummyController(CityInfoDBContext context)
        {
            // just by instantiating the CityInfoDBContext we should at the very least get some blank tables created.
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

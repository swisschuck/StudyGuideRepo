using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIStudyGuide.Models.Other
{
    public class PointOfInterestForCreationDto
    {
        // its good practice to have seperate DTO's that are meant to be used by clients for API calls. This allows us to remain decoupled to
        // the objects we are sending to clients and the objects we are using in the actual API. If for some reason we need to refactor the client
        // facing ones, we wont need to refractor all the other DTO's that are being used by the app internally.
        #region fields
        #endregion fields


        #region properties

        public string Name { get; set; }

        public string Description { get; set; }

        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

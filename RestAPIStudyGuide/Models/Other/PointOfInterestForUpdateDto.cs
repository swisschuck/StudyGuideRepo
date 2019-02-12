using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIStudyGuide.Models.Other
{
    public class PointOfInterestForUpdateDto
    {
        #region fields
        #endregion fields


        #region properties

        [Required(ErrorMessage = "please provide a value for the name.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "The max size for description is 200.")]
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

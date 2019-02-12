using System.ComponentModel.DataAnnotations;

namespace RestAPIStudyGuide.Models.Other
{
    public class PointOfInterestForCreationDto
    {
        // its good practice to have seperate DTO's that are meant to be used by clients for API calls. This allows us to remain decoupled to
        // the objects we are sending to clients and the objects we are using in the actual API. If for some reason we need to refactor the client
        // facing ones, we wont need to refractor all the other DTO's that are being used by the app internally.


        // we can use data annotation attributes (https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netframework-4.7.2) 
        // in unison with our built in .NET serializer to make sure certain fields/properties are setup properly for client consuming API calls:
        //
        // + [Required] - indicates a required field
        #region fields
        #endregion fields


        #region properties

        //[Required] - we can simply add the Required attribute to make it required or we can add a returning error message for the client
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

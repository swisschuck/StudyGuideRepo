using RestAPIStudyGuide.Models.Other;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPIStudyGuide.EntityFramework.Entities.Other
{
    public class PointOfInterestEntity
    {
        #region fields
        #endregion fields


        #region properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        // we need to create a relationship between this child object to our City parent object. we can do this by making this property a navigation property.
        // by convention EF will search the other objects in the system and make the link for us. its not required to explicity declare a foreign key but we
        // should define one for clarity
        [ForeignKey("CityId")]
        public CityDto City { get; set; }

        public int CityId { get; set; }

        [MaxLength(200)]
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

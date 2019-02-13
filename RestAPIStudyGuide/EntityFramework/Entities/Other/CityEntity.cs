using RestAPIStudyGuide.Models.Other;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPIStudyGuide.EntityFramework.Entities.Other
{
    public class CityEntity
    {
        #region fields
        #endregion fields


        #region properties

        // just by giving a property in our class the name Id, it will automatically become the primary key for the EF table. However we can/should
        // label it with the EF key attribute

        // DatabaseGeneratedOption.Identity - for generation on add or update
        // DatabaseGeneratedOption.Computed - for generation on add
        // DatabaseGeneratedOption.None - for no generation

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();

        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

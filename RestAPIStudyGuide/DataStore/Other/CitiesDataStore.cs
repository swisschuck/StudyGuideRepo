using RestAPIStudyGuide.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIStudyGuide.DataStore.Other
{
    public class CitiesDataStore
    {
        #region fields
        #endregion fields


        #region properties

        public List<CityDto> Cities { get; set; }

        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        #endregion properties


        #region constructors

        public CitiesDataStore()
        {
            // initial dummy data
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Denver",
                    Description = "Cant be beat",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "State Capital",
                            Description = "The capital city of Colorado"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Pepsi Center2",
                            Description = "A massive complex that hosts many of Denver's top events."
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "New York",
                    Description = "Why?...Just Why?",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Lots of rude people",
                            Description = "Can be found anywhere in the city"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "Statue Of Liberty",
                            Description = "A once great symbol of American freedom, now a long forgotten toilet for the pigeons."
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Loveland",
                    Description = "The City of Love",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 5,
                            Name = "Bronze Sculptor Garden",
                            Description = "Located at the center of loveland, contains many beautiful works or art"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "Piece and Quiet",
                            Description = "Can be found almost anywhere in the city"
                        }
                    }
                },
            };
        }
        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

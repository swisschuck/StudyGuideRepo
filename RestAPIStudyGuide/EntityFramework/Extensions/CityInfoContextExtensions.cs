using RestAPIStudyGuide.EntityFramework.Context.Other;
using RestAPIStudyGuide.EntityFramework.Entities.Other;
using RestAPIStudyGuide.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIStudyGuide.EntityFramework.Extensions
{
    public static class CityInfoContextExtensions
    {
        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region public methods

        // by using the "this" keyword with the type we are telling the compiler to extend the type with this method.
        public static void EnsureSeedDataForContext(this CityInfoDBContext context)
        {
            if (context.Cities.Any())
            {
                // if we already have data then we dont want to insert anything
                return;
            }

            // init seed data
            var cities = new List<CityDto>()
            {
                new CityDto()
                {
                     Name = "New York City",
                     Description = "The one with that big park.",
                     PointsOfInterest = new List<PointOfInterestDto>()
                     {
                         new PointOfInterestDto() {
                             Name = "Central Park",
                             Description = "The most visited urban park in the United States."
                         },
                          new PointOfInterestDto() {
                             Name = "Empire State Building",
                             Description = "A 102-story skyscraper located in Midtown Manhattan."
                          },
                     }
                },
                new CityDto()
                {
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                     {
                         new PointOfInterestDto() {
                             Name = "Cathedral",
                             Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
                         },
                          new PointOfInterestDto() {
                             Name = "Antwerp Central Station",
                             Description = "The the finest example of railway architecture in Belgium."
                          },
                     }
                },
                new CityDto()
                {
                    Name = "Paris",
                    Description = "The one with that big tower.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                     {
                         new PointOfInterestDto() {
                             Name = "Eiffel Tower",
                             Description =  "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
                         },
                          new PointOfInterestDto() {
                             Name = "The Louvre",
                             Description = "The world's largest museum."
                          },
                     }
                }
            };

            context.Cities.AddRange(cities); // adding initial cities to the context
            context.SaveChanges(); // then save them, this will be what actually saves the information to the DB.
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

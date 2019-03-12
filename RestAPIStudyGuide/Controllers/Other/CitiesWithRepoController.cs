using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestAPIStudyGuide.DataStore.Other;
using RestAPIStudyGuide.Models.Other;
using RestAPIStudyGuide.Services.Other;

namespace RestAPIStudyGuide.Controllers.Other
{
    [Route("api/citiesWithRepo")]
    public class CitiesWithRepoController : Controller
    {
        #region fields

        private ICityInfoRepository _cityInfoRepository;

        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public CitiesWithRepoController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        #endregion constructors


        #region public methods

        [HttpGet()]
        public IActionResult GetCities()
        {
            IEnumerable<CityDto> repoCities = _cityInfoRepository.GetCities();

            List<CityWithoutPointsOfInterestDto> results = new List<CityWithoutPointsOfInterestDto>();

            // converting the city dto to a dto that we can send back (doesnt have the NumberOfPointsOfInterest)
            foreach (CityDto repoCity in repoCities)
            {
                results.Add(new CityWithoutPointsOfInterestDto
                {
                    Id = repoCity.Id,
                    Name = repoCity.Name,
                    Description = repoCity.Description
                });
            }

            return Ok(results);
        }


        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            CityDto city = _cityInfoRepository.GetCity(id, includePointsOfInterest);

            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                CityDto cityDto = new CityDto()
                {
                    Id = city.Id,
                    Name = city.Description,
                    Description = city.Description
                };

                foreach(PointOfInterestDto poi in city.PointsOfInterest)
                {
                    cityDto.PointsOfInterest.Add(
                        new PointOfInterestDto()
                        {
                            Id = poi.Id,
                            Name = poi.Name,
                            Description = poi.Description
                        });
                }

                return Ok(cityDto);
            }

            CityWithoutPointsOfInterestDto cwpoi = new CityWithoutPointsOfInterestDto()
            {
                Id = city.Id,
                Name = city.Name,
                Description = city.Description
            };

            return Ok(cwpoi);
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

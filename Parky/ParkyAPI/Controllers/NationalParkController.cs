using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.DTOs;
using ParkyAPI.Repository.Common;
using System.Collections.Generic;

namespace ParkyAPI.Controllers
{
    public class NationalParkController : BaseAPIController
    {
        private readonly INationalParkRepository _nationalParkRepository;
        private readonly IMapper _mapper;
        public NationalParkController(INationalParkRepository nationalParkRepository, IMapper mapper)
        {
            _nationalParkRepository = nationalParkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetNationalParks()
        {
            var nationalParks = _nationalParkRepository.GetNationalParks();

            var dtoList = new List<NationalParkDto>();

            foreach (var item in nationalParks)
            {
                dtoList.Add(_mapper.Map<NationalParkDto>(item));
            }

            return Ok(dtoList);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetNationalPark(int id)
        {
            var nationalPark = _nationalParkRepository.GetNationalPark(id);

            if (nationalPark == null)
                return NotFound();

            return Ok(_mapper.Map<NationalParkDto>(nationalPark));
        }

        [HttpGet("{name}")]
        public bool NationalParkExists(string name)
        {
            var nationalParkExists = _nationalParkRepository.NationalParkExists(name);

            return nationalParkExists;
        }

        /*         
        bool NationalParkExists(string name);
        bool NationalParkExists(int id);
        bool CreateNationalPark(NationalPark nationalPark);
        bool UpdateNationalPark(NationalPark nationalPark);
        bool DeleteNationalPark(NationalPark nationalPark);
        */
    }
}

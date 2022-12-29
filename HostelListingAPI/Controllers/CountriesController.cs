using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Core.models;
using AutoMapper;
using HotelListing.API.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using HotelListing.API.Core.Exceptions;
using Microsoft.AspNetCore.OData.Query;

namespace HotelListing.API.Core.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;
        private readonly ILogger<CountriesController> _logger;

        public CountriesController(IMapper mapper, ICountriesRepository countriesRepository,
            ILogger<CountriesController> logger)
        {
            _mapper = mapper;
            _countriesRepository = countriesRepository;
            _logger = logger;
        }

        // GET: api/Countries/GetAll
        [HttpGet("GetAll")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var countries = await _countriesRepository.GetAllAsync<GetCountryDto>();
            //var records = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(countries);
        }


        // GET: api/Countries/?StartIndex=0&PageSize=25&PageNumber=1
        [HttpGet]
        public async Task<ActionResult<PagedResult<GetCountryDto>>> GetPagedCountries([FromQuery] QueryParameters queryParameters)
        {
            var pagedCountriesResult = await _countriesRepository.GetAllAsync<GetCountryDto>(queryParameters);
            return Ok(pagedCountriesResult);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _countriesRepository.GetDetails(id);

            //if (country == null)
            //{
            //    throw new NotFoundException(nameof(GetCountry), id);
            //    //_logger.LogWarning($"Record not found in {nameof(GetCountry)} with Id: {id}. ");
            //    //return NotFound();
            //}

            //var countryDto = _mapper.Map<CountryDto>(country);

            return Ok(country);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            //THIS IS TRACKING THE ENTITY
            //_context.Entry(country).State = EntityState.Modified;
            

            ////THIS IS TRACKING THE ENTITY
            //var country = await _countriesRepository.GetAsync(id);

            //if(country == null)
            //{
            //    throw new NotFoundException(nameof(GetCountry), id);
            //    //return NotFound();
            //}

            ////ENTITY STATE MODIFIED
            //_mapper.Map(updateCountryDto, country);

            try
            {
                await _countriesRepository.UpdateAsync(id,updateCountryDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountryDto)
        {
            //var country = new Country
            //{
            //    Name = createCountryDto.Name,
            //    ShortName = createCountryDto.ShortName
            //};

            //var country = _mapper.Map<Country>(createCountryDto);

            var country = await _countriesRepository.AddAsync<CreateCountryDto,GetCountryDto>(createCountryDto);

            return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles="Administrator")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            //var country = await _countriesRepository.GetAsync(id);
            //if (country == null)
            //{
            //    throw new NotFoundException(nameof(GetCountry), id);
            //    //return NotFound();
            //}

            await _countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}

using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.DTO;
using TodoApi.Models;
using TodoApi.Services;
using TodoApi.Validations;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private IValidator<BeerInsertDTO> _beerInsertValidator;
        private IValidator<BeerUpdateDTO> _beerUpdateValidator;
        private IBeerService _beerService;
        public BeerController(
            IValidator<BeerInsertDTO> beerInsertValidator,
            IValidator<BeerUpdateDTO> beerUpdateValidator,
            IBeerService beerService
        )
        {
            _beerInsertValidator = beerInsertValidator;
            _beerUpdateValidator = beerUpdateValidator;
            _beerService = beerService;
        }


        [HttpGet]
        public async Task<IEnumerable<BeerDTO>> Get()
        {
            return await _beerService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDTO>> GetById(int id)
        {
            var beer = await _beerService.GetById(id);

            return beer is null ? NotFound() : Ok(beer);
        }

        [HttpPost]
        public async Task<ActionResult<BeerDTO>> Add(BeerInsertDTO beerInsertDTO)
        {
            var validationResult = await _beerInsertValidator.ValidateAsync(beerInsertDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var beerDTO = await _beerService.Add(beerInsertDTO);

            return CreatedAtAction(nameof(GetById), new { id = beerDTO.Id }, beerDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDTO>> Update(int id, BeerUpdateDTO beerUpdateDTO)
        {
            var validationResult = await _beerUpdateValidator.ValidateAsync(beerUpdateDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var beer = await _beerService.Update(id, beerUpdateDTO);

            return beer is null ? NotFound() : Ok(beer);


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BeerDTO>> Delete(int id)
        {
            var beer = await _beerService.Delete(id);
            return beer is null ? NotFound() : Ok(beer);
        }

    }
}

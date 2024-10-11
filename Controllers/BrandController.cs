using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.DTO;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        private readonly Context _context;
        public BrandController(Context context)
        {
            _context = context;
        }

       
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(BrandDTO brand)
        {
            var newBrand = new Brand
            {
                Name = brand.Name
            };

            await _context.Brands.AddAsync(newBrand);

            await _context.SaveChangesAsync();

            return Ok(newBrand);
        }
    }
}

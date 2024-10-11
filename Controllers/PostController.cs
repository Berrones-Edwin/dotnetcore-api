using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.DTO;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService _titleService;

        public PostController(IPostService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDTO>> Get()=>await _titleService.Get();
    }
}

using FilRouge.Classes;
using FilRouge.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilRouge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IRepository<Post> _postRepository;

        public PostController(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        // GET: api/<APIController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_postRepository.GetAll());
        }

        // GET api/<APIController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_postRepository.Get(id));
        }

        // POST api/<APIController>
        [HttpPost]
        public IActionResult Post([FromForm] Post post)
        {
            return Ok(_postRepository.Add(post));
        }

        // PUT api/<APIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] Post post)
        {
            return Ok(_postRepository.Update(id, post));
        }

        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_postRepository.Delete(id));
        }
    }
}

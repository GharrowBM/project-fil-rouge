using FilRouge.Classes;
using FilRouge.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilRouge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private IRepository<Tag> _tagRepository;

        public TagController(IRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        // GET: api/<APIController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tagRepository.GetAll());
        }

        // GET api/<APIController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_tagRepository.Get(id));
        }

        // tag api/<APIController>
        [HttpPost]
        public IActionResult tag([FromForm] Tag tag)
        {
            return Ok(_tagRepository.Add(tag));
        }

        // PUT api/<APIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] Tag tag)
        {
            return Ok(_tagRepository.Update(id, tag));
        }

        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_tagRepository.Delete(id));
        }
    }
}

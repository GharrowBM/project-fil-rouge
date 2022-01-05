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
            Tag tagToGet = _tagRepository.Get(id);

            if (tagToGet != null)
            {
                return Ok(tagToGet);
            }

            return NotFound(new {Message = "Cannot GET that tag..."});
        }

        // tag api/<APIController>
        [HttpPost]
        public IActionResult Post([FromForm] Tag tag)
        {
            if (_tagRepository.Add(tag))
            {
                return Ok(new {Message = $"{tag.Name} successfully added!"});
            }

            return NotFound(new {Message = $"{tag.Name} cannot be added..."});
        }

        // PUT api/<APIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] Tag tag)
        {
            Tag tagToEdit = _tagRepository.Get(id);

            if (tagToEdit != null)
            {
                tagToEdit.Name = tag.Name;

                if (_tagRepository.Update(id, tagToEdit))
                {
                    return Ok(new {Mesage=$"{tag.Name} was edited with success!"});
                }
            }

            return NotFound(new {Message = $"{tag.Name} cannot be edited..."});
        }

        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_tagRepository.Delete(id))
            {
                return Ok(new {Message = "Tag" + id + " was successfully deleted!"});
            }

            return NotFound(new {Message = "Tag " + id + " cannot be deleted..."});
        }
    }
}

using FilRouge.Classes;
using FilRouge.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("allConnections")]
    [ApiController]
    public class CommentsController : Controller
    {
        private IRepository<Comment> _commentRepository;

        public CommentsController(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        // GET: api/<APIController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_commentRepository.GetAll());
        }
        
        // GET api/<APIController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Comment commentToGet = _commentRepository.Get(id);

            if (commentToGet != null)
            {
                return Ok(commentToGet);
            }

            return NotFound(new {Message = "Cannot GET this post..."});
        }

        // POST api/<APIController>
        [HttpPost]
        public IActionResult Post([FromBody] Comment comment)
        {
            if (_commentRepository.Add(comment))
            {
                return Ok(new {Message=$"{comment.Content} successfully added to database!"});    
            }
            
            return NotFound(new {Message=$"{comment.Content} cannot be added to database..."});
            
            
        }

        // PUT api/<APIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Comment comment)
        {
            if (_commentRepository.Update(id, comment))
            {
                return Ok(new {Message = $"{comment.Content} modified with success!"});
            }
            
            return NotFound(new {Message = $"{comment.Content} cannot be modified..."});
        }

        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_commentRepository.Delete(id))
            {
                return Ok(new {Message = "Comment " + id + " deleted with success!"});
            }

            return NotFound(new {Message = "Comment " + id + " cannot be deleted..."});
        }
    }
}
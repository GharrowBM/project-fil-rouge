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
    public class AnswersController : Controller
    {
        private IRepository<Answer> _answerRepository;

        public AnswersController(IRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        // GET: api/<APIController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_answerRepository.GetAll());
        }
        
        // GET api/<APIController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Answer answerToGet = _answerRepository.Get(id);

            if (answerToGet != null)
            {
                return Ok(answerToGet);
            }

            return NotFound(new {Message = "Cannot GET this post..."});
        }

        // POST api/<APIController>
        [HttpPost]
        public IActionResult Post([FromBody] Answer answer)
        {
            if (_answerRepository.Add(answer))
            {
                return Ok(new {Message=$"{answer.Content} successfully added to database!"});    
            }
            
            return NotFound(new {Message=$"{answer.Content} cannot be added to database..."});
            
            
        }

        // PUT api/<APIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Answer answer)
        {
            if (_answerRepository.Update(id, answer))
            {
                return Ok(new {Message = $"{answer.Content} modified with success!"});
            }
            
            return NotFound(new {Message = $"{answer.Content} cannot be modified..."});
        }

        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_answerRepository.Delete(id))
            {
                return Ok(new {Message = "Answer " + id + " deleted with success!"});
            }

            return NotFound(new {Message = "Answer " + id + " cannot be deleted..."});
        }
    }
}
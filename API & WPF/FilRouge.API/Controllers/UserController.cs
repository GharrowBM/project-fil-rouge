using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FilRouge.Classes;
using FilRouge.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilRouge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository) 
        {
            _userRepository = userRepository;
        }

        // GET: api/<APIController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userRepository.GetAll());
        }

        // GET api/<APIController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User userToGet = _userRepository.Get(id);

            if (userToGet != null)
            {
                return Ok(userToGet);
            }

            return NotFound(new {Message = "Cannot GET this user..."});
        }

        // POST api/<APIController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (_userRepository.Add(user))
            {
                return Ok(new {Message = $"{user.Username} successfully added to database!"});
            }

            return NotFound(new {Message = $"{user.Username} cannot be added to database..."});
        }

        [HttpPost("login")]
        public string Login(string username, string password)
        {
            if (username == "test" && password == "pass")
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, username),                  
                    new Claim(ClaimTypes.Role, "admin"),
                };

                //Objet pour signer le token
                SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bonjour, je suis la clé de cryptage!")), SecurityAlgorithms.HmacSha256);


                //Créer notre jwt
                JwtSecurityToken jwt = new JwtSecurityToken(issuer: "m2i", audience: "m2i", claims: claims, signingCredentials: signingCredentials, expires: DateTime.Now.AddDays(2));
                return new JwtSecurityTokenHandler().WriteToken(jwt);
            }

            return null;
        }

        // PUT api/<APIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            User userToEdit = _userRepository.Get(id);

            if(userToEdit != null)
            {
                userToEdit.FirstName = user.FirstName;
                userToEdit.LastName = user.LastName;
                userToEdit.Username = user.Username;
                userToEdit.Password = user.Password;
                userToEdit.AvatarPath = user.AvatarPath;
                userToEdit.Email = user.Email;
                userToEdit.IsBlacklisted = user.IsBlacklisted;
                userToEdit.Posts = user.Posts;
                userToEdit.Answers = user.Answers;
                userToEdit.Comments = user.Comments;
                userToEdit.FavoriteTags = user.FavoriteTags;
                
                if (_userRepository.Update(id, userToEdit))
                {
                    return Ok(new {Message=$"{user.Username} successfully edited!"});
                }
            }
            
            return NotFound(new {Message = $"{user.Username} cannot be edited..."});
        }

        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_userRepository.Delete(id))
            {
                return Ok(new {Message = "User " + id + " successfully deleted!"});
            }

            return NotFound(new {Message = "User" + id + " cannot be deleted..."});
        }
    }
}

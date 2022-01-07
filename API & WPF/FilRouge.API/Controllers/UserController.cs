using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FilRouge.API.Services;
using FilRouge.Classes;
using FilRouge.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilRouge.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("allConnections")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepository<User> _userRepository;
        private UploadService _uploadService;

        public UserController(IRepository<User> userRepository, UploadService uploadService) 
        {
            _userRepository = userRepository;
            _uploadService = uploadService;
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

        
        [HttpPost]
        public IActionResult Post([FromForm] IFormFile file, [FromForm] string username, [FromForm] string password, [FromForm] string lastname, [FromForm] string firstname, [FromForm] string email)
        {
            User user = new User()
            {
                Username = username,
                Password = password,
                LastName = lastname,
                FirstName = firstname,
                AvatarPath = _uploadService.Upload(file),
                Email = email
            };
            
            if (_userRepository.Add(user))
            {
                return Ok(new {Message = $"{user.Username} successfully added to database!"});
            }

            return NotFound(new {Message = $"{user.Username} cannot be added to database..."});
        }
        
        /*[HttpPost]
        public IActionResult Post(string email, string password, string username, string avatarPath, string firstname, string lastname)
        {
            User user = new User()
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                AvatarPath = avatarPath,
                Username = username,
                Password = password
            };
            
            if (_userRepository.Add(user))
            {
                return Ok(new {Message = $"{user.Username} successfully added to database!"});
            }

            return NotFound(new {Message = $"{user.Username} cannot be added to database..."});
        }*/

        [HttpPost("login")]
        public IActionResult Login([FromForm] string username, [FromForm] string password)
        {
            User userToFind = _userRepository.Search(u => u.Username == username && u.Password == password);
            
            if (userToFind != null)
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
                return Ok(new {Token= new JwtSecurityTokenHandler().WriteToken(jwt), UserId= userToFind.Id});
            }

            return NotFound(new {Message="Something went wrong"});
        }

        // PUT api/<APIController>/5
        [Authorize(Policy = "admin")]
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

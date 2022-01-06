using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilRouge.Classes
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AvatarPath { get; set; }
        public string Email { get; set; }
        public DateTime RegisterAt { get; set; }
        public bool IsBlacklisted { get; set; }
        [JsonIgnore]
        public virtual List<Post> Posts { get; set; }
        [JsonIgnore]
        public virtual List<Answer> Answers { get; set; }
        [JsonIgnore]
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Tag> FavoriteTags { get; set; }

        public User()
        {
            RegisterAt = DateTime.Now;
            IsBlacklisted = false;
            Posts = new List<Post>();
            Answers = new List<Answer>();
            Comments = new List<Comment>();
            FavoriteTags = new List<Tag>();
        }
    }
}

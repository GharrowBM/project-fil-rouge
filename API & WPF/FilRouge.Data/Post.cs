using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilRouge.Classes
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public int Score { get; set; }


        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual List<Tag> Tags { get; set; }

        public Post()
        {
            Score = 0;
            CreatedAt = DateTime.Now;
            Answers = new List<Answer>();
            Tags = new List<Tag>();
        }
    }
}

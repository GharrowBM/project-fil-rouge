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
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public int Score { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int AnswerId { get; set; }
        [ForeignKey("AnswerId")]
        [JsonIgnore]
        public virtual Answer Answer { get; set; }

        public Comment()
        {
            CreatedAt = DateTime.Now;
            EditedAt = DateTime.Now;
            Score = 0;
        }
    }
}

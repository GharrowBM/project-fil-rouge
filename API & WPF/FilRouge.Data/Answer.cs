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
    public  class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public int Score { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual User User { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        [JsonIgnore]
        public virtual Post Post { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}

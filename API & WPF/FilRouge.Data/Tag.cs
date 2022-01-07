using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilRouge.Classes
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<User> Subscribers { get; set; }
        [JsonIgnore]
        public virtual List<Post> RelatedPosts { get; set; }
    }
}

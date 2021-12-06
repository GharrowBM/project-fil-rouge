﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Uri AvatarURI { get; set; }
        public string Email { get; set; }
        public DateTime RegisterAt { get; set; }
        public bool IsBlacklisted { get; set; }

        public virtual List<Post> Posts { get; set; }
        public virtual List<Tag> FavoriteTags { get; set; }
    }
}

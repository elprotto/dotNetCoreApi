using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities
{
    public partial class User: BaseEntity
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Post = new HashSet<Post>();
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}

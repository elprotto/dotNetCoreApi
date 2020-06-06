using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}

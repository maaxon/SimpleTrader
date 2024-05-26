using System;

namespace SimpleTrader.Domain.Models
{
    public class User : DomainObject
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DatedJoined { get; set; }
        public string Role { get; set; }
        public string Theme { get; set; }
        public string Lang { get; set; }

        public string Img { get; set; }
    }
}

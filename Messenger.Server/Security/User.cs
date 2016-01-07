using System;

namespace Messenger.Server.Security
{
    public class User
    {
        public Guid Id { get; set; }
        public Team Team { get; set; } 
    }
}
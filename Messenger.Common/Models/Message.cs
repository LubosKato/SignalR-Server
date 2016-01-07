using System;
using Messenger.Common.Enums;

namespace Messenger.Common.Models
{
    public class Message
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public MessageType Type { get; set; }
        public Guid Who { get; set; }
        public string Sender { get; set; }
    }
}
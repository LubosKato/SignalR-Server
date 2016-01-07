using System;
using Messenger.Client;
using Messenger.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSClient
{
    [TestClass]
    public class Client
    {
        [TestMethod]
        public void SendMessage()
        {
            var client = new MessengerClient();
            client.OpenConnection("MessengerHub");
            client.SendMessage(new Message
            {
                Title = "Test",
                Content = "Content",
                Sender = "Test Client",
                Type = Messenger.Common.Enums.MessageType.Info,
                Who = Guid.Parse("dc7c3655-18c1-4dbc-b27f-fbaa19d50fbd")
            });
        }
    }
}

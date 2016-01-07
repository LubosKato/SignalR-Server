using System;
using System.Configuration;
using System.Net;
using Messenger.Client.Abstractions;
using Messenger.Common.Models;
using Microsoft.AspNet.SignalR.Client;

namespace Messenger.Client
{
    public class MessengerClient : IMessengerClient
    {
        public IHubProxy Hub { get; set; }
        public HubConnection HubConnection { get; set; }
        private const string hubSend = "Send";

        public void OpenConnection(string messengerHub)
        {
            try
            {
                HubConnection = new HubConnection(ConfigurationManager.AppSettings["MessengerUri"]);
                HubConnection.Credentials = CredentialCache.DefaultCredentials;
                Hub = HubConnection.CreateHubProxy(messengerHub);

                HubConnection.Start().ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        throw new Exception(string.Format(
                            "There was an error opening the connection: {0}", task.Exception.GetBaseException()));
                    }

                }).Wait();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Problem encoutered while connecting to messenger: {0}", ex));
            }
        }

        public void SendMessage(Message message)
        {
            try
            {
                Hub.Invoke(hubSend, message)
                    .ContinueWith(task =>
                    {
                        if (task.IsFaulted)
                        {
                            throw new Exception("There was an error calling Send: {0}",
                                task.Exception.GetBaseException());
                        }
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Problem encoutered while sending message to messenger: {0}", ex));
            }
        }

        public void CloseConnection()
        {
            HubConnection.Stop();
        }
    }
}

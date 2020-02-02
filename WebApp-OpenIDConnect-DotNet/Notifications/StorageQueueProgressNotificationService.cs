using System;

using Azure.Storage.Queues;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApp_OpenIDConnect_DotNet.Models
{
    public class StorageQueueProgressNotificationService<T> : StorageQueueProgressNotificationService, IProgressNotificationService<T>
    {
        public StorageQueueProgressNotificationService(QueueClient qc, string tenantId) : base(qc, tenantId) { }

        public void Notify(IEnumerable<T> satisfiedRequirements)
        {
            throw new NotImplementedException();
        }
    }

    public class StorageQueueProgressNotificationService : IProgressNotificationService
    {
        private readonly QueueClient _queueClient;
        private readonly string _identifier;

        public StorageQueueProgressNotificationService(QueueClient qc, string tenantId)
        {
            _queueClient = qc;
            _identifier = tenantId;
        }

        public void Notify(IEnumerable<IAuthorizationRequirement> satisfiedRequirements)
        {
            Notify(new NotificationMessage(_identifier, satisfiedRequirements));
        }

        public void Notify(NotificationMessage message)
        {
            message.Identifier = _identifier;
            var data = JsonConvert.SerializeObject(message);
            _queueClient.SendMessage(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(data)));
        }
    }
}
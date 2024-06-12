using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs;
using ReceiveEvents.IServices;
using System.Text;
using Microsoft.Extensions.Configuration;
using ReceiveEvents.CustomExceptions;
using ReceiveEvents.Configuration;


namespace ReceiveEvents.Services
{
    public class EventSendingService : IEventSendingService
    {
        private readonly SecretsConfigurations _secretConfigurations;

        public EventSendingService(SecretsConfigurations secretConfigurations)
        {
            _secretConfigurations = secretConfigurations;
        }

        public async Task SendEventAsync(string eventData)
        {
            var connectionString = _secretConfigurations.SenderEventHubConnectionString;
            var eventHubName = _secretConfigurations.EventHubName;

            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(eventHubName))
            {
                throw new InvalidRequestException("Invalid configuration: Sender Event Hub connection string or event hub name is missing.");
            }

            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                using (EventDataBatch eventBatch = await producerClient.CreateBatchAsync())
                {
                    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(eventData)));
                    await producerClient.SendAsync(eventBatch);
                }
            }
        }
    }
}

using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs;
using Azure.Storage.Blobs;
using ReceiveEvents.IServices;
using System.Text;
using Microsoft.Extensions.Configuration;
using ReceiveEvents.CustomExceptions;
using ReceiveEvents.Configuration;

namespace ReceiveEvents.Services
{
    public class EventProcessingService : IEventProcessingService
    {
        private readonly SecretsConfigurations _secretConfigurations;
        private EventProcessorClient _processor;

        public EventProcessingService(SecretsConfigurations secretConfigurations)
        {
            _secretConfigurations = secretConfigurations;
        }

        public async Task StartProcessingAsync()
        {
            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            BlobContainerClient storageClient = new BlobContainerClient(_secretConfigurations.BlobStorageConnectionString, _secretConfigurations.BlobContainerName);

            _processor = new EventProcessorClient(storageClient, consumerGroup, _secretConfigurations.ReceiverEventHubConnectionString, _secretConfigurations.EventHubName);
            _processor.ProcessEventAsync += ProcessEventHandler;
            _processor.ProcessErrorAsync += ProcessErrorHandler;

            await _processor.StartProcessingAsync();
        }

        public async Task StopProcessingAsync()
        {
            if (_processor != null)
            {
                await _processor.StopProcessingAsync();
                _processor = null;
            }
            else
            {
                throw new InvalidRequestException("Event processing is not running.");
            }
        }

        private Task ProcessEventHandler(ProcessEventArgs eventArgs)
        {
            Console.WriteLine("\tReceived event: {0}", Encoding.UTF8.GetString(eventArgs.Data.Body.ToArray()));
            return eventArgs.UpdateCheckpointAsync(eventArgs.CancellationToken);
        }

        private Task ProcessErrorHandler(ProcessErrorEventArgs eventArgs)
        {
            Console.WriteLine($"\tPartition '{eventArgs.PartitionId}': an unhandled exception was encountered.");
            Console.WriteLine(eventArgs.Exception.Message);
            return Task.CompletedTask;
        }
    }
}

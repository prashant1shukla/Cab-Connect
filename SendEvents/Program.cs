﻿using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;


namespace SendEvents
{
    internal class Program
    {
        private const string connectionString = "";
        private const string eventHubName = "";
        static async Task Main()
        {
            // Create a prodicer client that you can use to send events to an event hub
            await using(var producerClient =  new EventHubProducerClient(connectionString, eventHubName))
            {
                //Create batch of events
                using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();

                //Add events to batch. An event is represented  by a collection of bytes and metadata
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First event")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Second event")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Third event")));

                // Use the producer client to send the batch of events to the event hub
                await producerClient.SendAsync(eventBatch);
                Console.WriteLine("A batch of 3 events has been published");
            }
        }
    }
}
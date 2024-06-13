namespace ReceiveEvents.Configuration
{
    public class SecretsConfigurations
    {
        public string ReceiverEventHubConnectionString { get; set; }
        public string EventHubName { get; set; }
        public string BlobStorageConnectionString { get; set; }
        public string BlobContainerName { get; set; }
        public string SenderEventHubConnectionString { get; set; }


    }
}

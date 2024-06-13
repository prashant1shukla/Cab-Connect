namespace ReceiveEvents.IServices
{
    public interface IEventProcessingService
    {
        Task StartProcessingAsync();
        Task StopProcessingAsync();
    }
}

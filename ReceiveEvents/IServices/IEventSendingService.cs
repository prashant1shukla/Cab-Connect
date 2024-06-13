namespace ReceiveEvents.IServices
{
    public interface IEventSendingService
    {
        Task SendEventAsync(string eventData);
    }
}

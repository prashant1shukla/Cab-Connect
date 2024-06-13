using Microsoft.AspNetCore.Mvc;
using ReceiveEvents.CustomExceptions;
using ReceiveEvents.IServices;

namespace ReceiveEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEventsController : ControllerBase
    {
        private readonly IEventSendingService _eventSendingService;
        public SendEventsController(IEventSendingService eventSendingService)
        {
            _eventSendingService = eventSendingService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEvent(string eventData)
        {
            try
            {
                await _eventSendingService.SendEventAsync(eventData);
                return Ok("Event sent successfully.");
            }
            catch (InvalidRequestException ex)
            {
                // Catch the custom exception and return a BadRequest with the exception message
                return BadRequest(ex.Message);
            }
        }
    }
}

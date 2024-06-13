using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Azure.Storage.Blobs;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using ReceiveEvents.IServices;
using ReceiveEvents.CustomExceptions;

namespace ReceiveEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiveEventsController : ControllerBase
    {
        private readonly IEventProcessingService _eventProcessingService;

        public ReceiveEventsController(IEventProcessingService eventProcessingService)
        {
            _eventProcessingService = eventProcessingService;
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartEventProcessing()
        {
            await _eventProcessingService.StartProcessingAsync();
            return Ok("Event processing started.");
        }

        [HttpPost("stop")]
        public async Task<IActionResult> StopEventProcessing()
        {
            try
            {
                await _eventProcessingService.StopProcessingAsync();
                return Ok("Event processing stopped.");
            }
            catch (InvalidRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

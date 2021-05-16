using arThek.ServiceAbstraction;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace arThek.API.Controllers
{
    [Route("arThek/[controller]")]
    [ApiController]
    public class LiveStreamingController : ControllerBase
    {
        private readonly ILiveStreamingService _liveStreamingService;
        public LiveStreamingController(ILiveStreamingService liveStreamingService)
        {
            _liveStreamingService = liveStreamingService;
        }

        [HttpPost]
        public async Task<IActionResult> SendRequest()
        {
            await _liveStreamingService.LiveStreaming();
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PowerDiaryChat.Domain.Dtos;
using PowerDiaryChat.Domain.Interfaces;
using System.Net.Mime;

namespace PowerDiaryChat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        /// <summary>
        /// Get chat history from repository
        /// </summary>
        /// <returns>Chat history as a list</returns>
        [HttpGet]
        [Route("chat")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<ChatRoomHistoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ChatRoomHistoryResponse>), StatusCodes.Status500InternalServerError)]
        public IActionResult GetChat()
        {
            var chatHistory = _chatService.GetChatRoomHistory();
            return Ok(chatHistory);
        }

        /// <summary>
        /// Aggregate chat history by hour
        /// </summary>
        /// <returns>Chat history aggregated by hour</returns>
        [HttpGet]
        [Route("hourly")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<ChatRoomHistoryHourlyResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ChatRoomHistoryHourlyResponse>), StatusCodes.Status500InternalServerError)]
        public IActionResult GetHourlyAggregation()
        {
            var chatHistory = _chatService.GetHourlyAggregatedEvents();
            return Ok(chatHistory);
        }
    }
}
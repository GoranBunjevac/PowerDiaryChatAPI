using PowerDiaryChat.Domain.Dtos;
using PowerDiaryChat.Domain.Interfaces;

namespace PowerDiaryChat.Domain.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        /// <inheritdoc />
        public List<ChatRoomHistoryResponse> GetChatRoomHistory()
        {
            var chatHistory = _chatRepository.GetChatHistory();

            var dto = chatHistory.GetEvents().Select(x => x.ToDto());

            return dto.ToList();
        }

        /// <inheritdoc />
        public List<ChatRoomHistoryHourlyResponse> GetHourlyAggregatedEvents()
        {
            var chatHistory = _chatRepository.GetChatHistory();

            var chatHistoryStartTime = chatHistory.GetEvents().Min(x => x.Timestamp);
            var chatHistoryEndTime = chatHistory.GetEvents().Max(x => x.Timestamp);
            var granularity = TimeSpan.FromHours(1);

            var aggregatedEvents = chatHistory.GetAggregatedEvents(chatHistoryStartTime, chatHistoryEndTime, granularity);

            var dto = aggregatedEvents.Select(x => x.ToDto());

            return dto.ToList();
        }
    }
}

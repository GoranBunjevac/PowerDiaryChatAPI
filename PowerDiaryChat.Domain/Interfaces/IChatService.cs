using PowerDiaryChat.Domain.Dtos;

namespace PowerDiaryChat.Domain.Interfaces
{
    public interface IChatService
    {
        /// <summary>
        /// Method to retrieve chat history
        /// </summary>
        /// <returns>Chat history response as dto</returns>
        List<ChatRoomHistoryResponse> GetChatRoomHistory();

        /// <summary>
        /// Method to aggregate chat history by hour
        /// </summary>
        /// <returns>Chat history aggregated by hour as dto</returns>
        List<ChatRoomHistoryHourlyResponse> GetHourlyAggregatedEvents();
    }
}

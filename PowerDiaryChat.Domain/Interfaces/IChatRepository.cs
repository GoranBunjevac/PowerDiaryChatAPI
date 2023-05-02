using PowerDiaryChat.Domain.Models;

namespace PowerDiaryChat.Domain.Interfaces
{
    public interface IChatRepository
    {
        /// <summary>
        /// Method to retrieve chat history
        /// </summary>
        /// <returns>Chat history as list of chat events</returns>
        ChatRoom GetChatHistory();
    }
}

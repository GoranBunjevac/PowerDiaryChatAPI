using PowerDiaryChat.Domain.Dtos;

namespace PowerDiaryChat.Domain.Models
{
    public class HourlyChatEvent
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }

        public ChatRoomHistoryHourlyResponse ToDto() => new(Timestamp, Message);
    }
}

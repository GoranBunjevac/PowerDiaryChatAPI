using PowerDiaryChat.Domain.Dtos;
using PowerDiaryChat.Domain.Enums;

namespace PowerDiaryChat.Domain.Models
{
    public class ChatEvent
    {
        public DateTime Timestamp { get; set; }
        public string Member { get; set; }
        public string OtherMember { get; set; }
        public ChatEventType Type { get; set; }
        public string Message { get; set; }

        public ChatRoomHistoryResponse ToDto() => new(Timestamp, Member, OtherMember, Type, Message);
    }
}

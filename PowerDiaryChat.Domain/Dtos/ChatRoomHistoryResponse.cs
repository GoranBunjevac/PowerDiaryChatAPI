using PowerDiaryChat.Domain.Enums;

namespace PowerDiaryChat.Domain.Dtos
{
    public class ChatRoomHistoryResponse
    {
        public DateTime Timestamp { get; set; }
        public string Member { get; set; }
        public string OtherMember { get; set; }
        public ChatEventType Type { get; set; }
        public string Message { get; set; }

        public ChatRoomHistoryResponse(DateTime timestamp, string member, string otherMember, ChatEventType type, string message)
        {
            Timestamp = timestamp;
            Member = member;
            OtherMember = otherMember;
            Type = type;
            Message = message;
        }
    }
}

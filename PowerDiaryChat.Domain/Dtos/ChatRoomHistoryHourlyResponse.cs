namespace PowerDiaryChat.Domain.Dtos
{
    public class ChatRoomHistoryHourlyResponse
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }

        public ChatRoomHistoryHourlyResponse(DateTime timestamp, string message)
        {
            Timestamp = timestamp;
            Message = message;
        }
    }
}

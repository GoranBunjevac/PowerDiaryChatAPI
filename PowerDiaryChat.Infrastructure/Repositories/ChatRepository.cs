using PowerDiaryChat.Domain.Enums;
using PowerDiaryChat.Domain.Interfaces;
using PowerDiaryChat.Domain.Models;

namespace PowerDiaryChat.Infrastructure.Repositories
{
    public class ChatRepository : IChatRepository
    {
        /// <inheritdoc />
        public ChatRoom GetChatHistory()
        {
            var chatRoom = new ChatRoom();

            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:00:00"), Member = "Kate", Type = ChatEventType.EnterRoom, Message = "Kate enters the room" });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:05:00"), Member = "Bob", Type = ChatEventType.EnterRoom, Message = "Bob enters the room" });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:05:00"), Member = "John", Type = ChatEventType.EnterRoom, Message = "John enters the room" });

            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:15:00"), Member = "Kate", Type = ChatEventType.Comment, Message = "Hi Bob! How are you doing today?" });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:16:00"), Member = "Bob", Type = ChatEventType.Comment, Message = "Hi Kate! I'm doing pretty well, thanks for asking. How about you?" });

            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:17:00"), Member = "Kate", Type = ChatEventType.Comment, Message = "I'm doing okay. I'm a little stressed out with work, but otherwise I'm doing fine." });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:17:00"), Member = "Bob", Type = ChatEventType.Comment, Message = "What's been stressing you out at work?" });

            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:20:00"), Member = "Kate", Type = ChatEventType.Comment, Message = "Just a lot of deadlines and projects that need to be completed. It's been a little overwhelming lately." });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:21:00"), Member = "Bob", Type = ChatEventType.Comment, Message = "I know the feeling. Have you tried breaking down your tasks into smaller, more manageable chunks?" });

            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:21:30"), Member = "John", Type = ChatEventType.Comment, Message = "Hey Guys I'm here just to high five you, Kate, Bob high five ?" });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:21:35"), Member = "John", OtherMember = "Kate", Type = ChatEventType.HighFive, Message = "✋" });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:21:40"), Member = "John", OtherMember = "Bob", Type = ChatEventType.HighFive, Message = "✋" });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:21:55"), Member = "Kate", Type = ChatEventType.Comment, Message = "Nice !" });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:21:55"), Member = "Bob", Type = ChatEventType.Comment, Message = "Nice !" });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:22:00"), Member = "John", Type = ChatEventType.LeaveRoom, Message = "John leaves the room" });

            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:22:00"), Member = "Kate", Type = ChatEventType.Comment, Message = "Yeah, anyway, I've been doing that, but it still feels like there's so much to do. Plus, I feel like I'm always working and never really taking a break." });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:22:00"), Member = "Bob", Type = ChatEventType.Comment, Message = "I hear you. Taking breaks is really important, though. It can help you recharge and be more productive in the long run." });

            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 18:35:00"), Member = "Kate", Type = ChatEventType.Comment, Message = "That's true. I've been trying to take more breaks, but sometimes it's hard to tear myself away from my work." });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 18:36:00"), Member = "Bob", Type = ChatEventType.Comment, Message = "Yeah, it can be tough. Have you tried setting a timer for yourself and taking a break once the timer goes off?" });

            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 18:37:00"), Member = "Kate", Type = ChatEventType.Comment, Message = "No, I haven't tried that. That's a good idea though. I'll give it a shot." });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 18:37:00"), Member = "Bob", Type = ChatEventType.Comment, Message = "Great! Let me know how it works out for you." });

            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 18:38:00"), Member = "Kate", Type = ChatEventType.Comment, Message = "Thanks Bob, I appreciate it. High Five" });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 18:39:00"), Member = "Kate", OtherMember = "Bob", Type = ChatEventType.HighFive, Message = "✋" });

            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 18:40:00"), Member = "Bob", Type = ChatEventType.Comment, Message = "Anytime Kate. Let me know if there's anything else I can do to help." });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:41:00"), Member = "Bob", OtherMember = "Kate", Type = ChatEventType.HighFive, Message = "✋" });

            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 18:42:00"), Member = "Kate", Type = ChatEventType.LeaveRoom, Message = "Kate leaves the room" });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 18:43:00"), Member = "Bob", Type = ChatEventType.LeaveRoom, Message = "Bob leaves the room" });

            return chatRoom;
        }
    }
}

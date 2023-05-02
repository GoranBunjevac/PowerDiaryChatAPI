using FluentAssertions;
using Moq;
using PowerDiaryChat.Domain.Enums;
using PowerDiaryChat.Domain.Interfaces;
using PowerDiaryChat.Domain.Models;
using Xunit;

namespace PowerDiaryChat.Tests.Repositories
{
    public class ChatRepositoryTests
    {
        private readonly Mock<IChatRepository> _chatRepositoryMock;

        public ChatRepositoryTests()
        {
            _chatRepositoryMock = new Mock<IChatRepository>();
        }

        [Fact]
        public void WhenCallingGetChatHistory_ShouldReturnChatHistory()
        {
            // Arrange
            var chatRoom = new ChatRoom();
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:00:00"), Member = "Kate", Type = ChatEventType.EnterRoom, Message = "Kate enters the room" });
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:05:00"), Member = "Bob", Type = ChatEventType.EnterRoom, Message = "Bob enters the room" });
            _chatRepositoryMock.Setup(x => x.GetChatHistory()).Returns(chatRoom);

            // When
            var result = _chatRepositoryMock.Object.GetChatHistory();

            // Then
            result.GetEvents().Should().NotBeEmpty();
            result.GetEvents().OfType<ChatEvent>();
            result.GetEvents().Count.Should().Be(2);
        }
    }
}

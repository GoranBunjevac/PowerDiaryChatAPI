using FluentAssertions;
using Moq;
using PowerDiaryChat.Domain.Enums;
using PowerDiaryChat.Domain.Interfaces;
using PowerDiaryChat.Domain.Models;
using PowerDiaryChat.Domain.Services;
using Xunit;

namespace PowerDiaryChat.Tests.Services
{
    public class ChatServiceTests
    {
        private readonly Mock<IChatRepository> _chatRepositoryMock;
        private readonly ChatRoom _chatRoom;

        public ChatServiceTests()
        {
            _chatRepositoryMock = new Mock<IChatRepository>();

            _chatRoom = new ChatRoom();
            _chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:00:00"), Member = "Kate", Type = ChatEventType.EnterRoom, Message = "Kate enters the room" });
            _chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:05:00"), Member = "Bob", Type = ChatEventType.EnterRoom, Message = "Bob enters the room" });
            _chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:15:00"), Member = "Kate", Type = ChatEventType.Comment, Message = "Hi Bob! How are you doing today?" });
            _chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:16:00"), Member = "Bob", Type = ChatEventType.Comment, Message = "Hi Kate! I'm doing pretty well, thanks for asking. How about you?" });
            _chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:20:00"), Member = "Kate", OtherMember = "Bob", Type = ChatEventType.HighFive, Message = "✋" });
        }

        [Fact]
        public void WhenGetChatRoomHistoryIsCalled_GetChatHistoryIsTriggered()
        {
            // Arrange
            var service = new ChatService(_chatRepositoryMock.Object);
            _chatRepositoryMock.Setup(x => x.GetChatHistory()).Returns(_chatRoom);

            // When
            var result = service.GetChatRoomHistory();

            // Then
            _chatRepositoryMock.Verify(x => x.GetChatHistory(), Times.Once);
        }

        [Fact]
        public void WhenGetChatRoomHistoryIsCalled_NumberOfEventsShouldBeCorrect()
        {
            // Arrange
            var service = new ChatService(_chatRepositoryMock.Object);
            _chatRepositoryMock.Setup(x => x.GetChatHistory()).Returns(_chatRoom);

            // When
            var result = service.GetChatRoomHistory();

            // Then
            result.Count.Should().Be(5);
        }

        [Fact]
        public void WhenGetHourlyAggregatedEventsIsCalled_PersonEnteredAndTimestampShouldBeFormatted()
        {
            // Arrange
            var service = new ChatService(_chatRepositoryMock.Object);
            _chatRepositoryMock.Setup(x => x.GetChatHistory()).Returns(_chatRoom);

            // When
            var result = service.GetHourlyAggregatedEvents();

            // Then
            result[0].Message.Should().NotBeEmpty();
            result[0].Message.Should().Contain("2 people entered");
            result[0].Message.Should().Contain("0 left");
            result[0].Message.Should().Contain("2 comments");
            result[0].Message.Should().Contain("1 person high-fived 1 other person");
            result[0].Timestamp.Should().Be(new DateTime(2023, 4, 27).AddHours(17));
        }
    }
}

using FluentAssertions;
using PowerDiaryChat.Domain.Enums;
using PowerDiaryChat.Domain.Models;
using Xunit;

namespace PowerDiaryChat.Tests.Models
{
    public class ChatRoomTests
    {
        [Fact]
        public void WhenInitializingChatRoom_ShouldBeEmpty()
        {
            // Arrange
            var chatRoom = new ChatRoom();

            // When + Then
            chatRoom.GetEvents().Should().BeEmpty();
        }

        [Fact]
        public void WhenMemberEntersTheRoom_EventShouldOccur()
        {
            // Arrange
            var chatRoom = new ChatRoom();
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:00:00"), Member = "Kate", Type = ChatEventType.EnterRoom, Message = "Kate enters the room" });

            // When
            var result = chatRoom.GetEvents();

            // Then
            result.Count.Should().Be(1);
            result[0].Member.Should().Be("Kate");
            result[0].OtherMember.Should().BeNull();
            result[0].Type.Should().Be(ChatEventType.EnterRoom);
        }

        [Fact]
        public void WhenMemberLeavesTheRoom_EventShouldOccur()
        {
            // Arrange
            var chatRoom = new ChatRoom();
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:00:00"), Member = "Bob", Type = ChatEventType.LeaveRoom, Message = "Bob leaves the room" });

            // When
            var result = chatRoom.GetEvents();

            // Then
            result.Count.Should().Be(1);
            result[0].Member.Should().Be("Bob");
            result[0].OtherMember.Should().BeNull();
            result[0].Type.Should().Be(ChatEventType.LeaveRoom);
        }

        [Fact]
        public void WhenMemberHighFives_EventShouldOccur()
        {
            // Arrange
            var chatRoom = new ChatRoom();
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:00:00"), Member = "Kate", OtherMember = "Bob", Type = ChatEventType.HighFive, Message = "Bob leaves the room" });

            // When
            var result = chatRoom.GetEvents();

            // Then
            result.Count.Should().Be(1);
            result[0].Member.Should().Be("Kate");
            result[0].OtherMember.Should().Be("Bob");
            result[0].Type.Should().Be(ChatEventType.HighFive);
        }

        [Fact]
        public void WhenMemberComments_EventShouldOccur()
        {
            // Arrange
            var chatRoom = new ChatRoom();
            chatRoom.AddEvent(new ChatEvent { Timestamp = DateTime.Parse("2023-04-27 17:00:00"), Member = "Kate", Type = ChatEventType.Comment, Message = "Hi guys, everything alright ?" });

            // When
            var result = chatRoom.GetEvents();

            // Then
            result.Count.Should().Be(1);
            result[0].Member.Should().Be("Kate");
            result[0].OtherMember.Should().BeNull();
            result[0].Type.Should().Be(ChatEventType.Comment);
        }
    }
}

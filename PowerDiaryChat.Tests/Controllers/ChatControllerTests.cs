using Moq;
using PowerDiaryChat.Api.Controllers;
using PowerDiaryChat.Domain.Interfaces;
using Xunit;

namespace PowerDiaryChat.Tests.Controllers
{
    public class ChatControllerTests
    {
        private readonly Mock<IChatService> _chatServiceMock;

        public ChatControllerTests()
        {
            _chatServiceMock = new Mock<IChatService>();
        }

        [Fact]
        public void WhenCallingGetChat_GetChatRoomHistoryIsCalledOnce()
        {
            // Arrange
            var controller = new ChatController(_chatServiceMock.Object);

            // When
            controller.GetChat();

            // Then
            _chatServiceMock.Verify(x => x.GetChatRoomHistory(), Times.Once);
        }

        [Fact]
        public void WhenCallingGetHourlyAggregation_GetHourlyAggregatedEventsIsCalledOnce()
        {
            // Arrange
            var controller = new ChatController(_chatServiceMock.Object);

            // When
            controller.GetHourlyAggregation();

            // Then
            _chatServiceMock.Verify(x => x.GetHourlyAggregatedEvents(), Times.Once);
        }
    }
}

using FluentAssertions;
using PowerDiaryChat.Domain.Enums;
using PowerDiaryChat.Domain.Helpers;
using Xunit;

namespace PowerDiaryChat.Tests.Helpers
{
    public class MessageBuilderHelperTests
    {
        [Fact]
        public void BuildMessage_ShouldReturnExpectedMessage()
        {
            // Arrange
            var countByEventType = new Dictionary<ChatEventType, int>
            {
                { ChatEventType.EnterRoom, 3 },
                { ChatEventType.LeaveRoom, 1 },
                { ChatEventType.Comment, 5 }
            };

            var countByUser = new Dictionary<string, IEnumerable<string>>
            {
                { "Alice", new List<string> { "Bob", "Charlie" } },
                { "Bob", new List<string> { "Alice", "David" } },
                { "Charlie", new List<string> { "Alice", "Eve" } },
                { "David", new List<string> { "Bob" } }
            };

            var expectedMessage = "3 people entered, 1 left, 4 people high-fived 4 other people, 5 comments";

            // When
            var result = MessageBuilderHelper.BuildMessage(countByEventType, countByUser);

            // Then
            result.Should().Be(expectedMessage);
        }

        [Theory]
        [InlineData("person", "people", 1, "person")]
        [InlineData("person", "people", 2, "people")]
        [InlineData("comment", "comments", 2, "comments")]
        public void AddPlural_CorrectlyAddsPluralToNoun(string singular, string plural, int occurrence, string expected)
        {
            var word = MessageBuilderHelper.AddPlural(occurrence, singular, plural);

            word.Should().Be(expected);
        }
    }
}

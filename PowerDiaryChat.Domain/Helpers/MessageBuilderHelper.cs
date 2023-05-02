using PowerDiaryChat.Domain.Enums;
using System.Text;

namespace PowerDiaryChat.Domain.Helpers
{
    public static class MessageBuilderHelper
    {
        /// <summary>
        /// Helper method to build aggregated event message by hour
        /// </summary>
        /// <param name="countByEventType">Number of events</param>
        /// <param name="countByUser">Number of users</param>
        /// <returns></returns>
        public static string BuildMessage(Dictionary<ChatEventType, int> countByEventType, Dictionary<string, IEnumerable<string>> countByUser)
        {
            var messageBuilder = new StringBuilder();

            // Number of people which high-fived other people
            var people = countByUser.Keys.Count;

            // Number of high-fived people
            var highFivedPeople = countByUser.Values.Distinct().Count();

            messageBuilder
                .Append(countByEventType.GetValueOrDefault(ChatEventType.EnterRoom, 0))
                .Append(AddPlural(countByEventType.GetValueOrDefault(ChatEventType.EnterRoom, 0), " person", " people"))
                .Append(" entered, ")
                .Append(countByEventType.GetValueOrDefault(ChatEventType.LeaveRoom, 0))
                .Append(" left, ")
                .Append(people)
                .Append(AddPlural(people, " person", " people"))
                .Append(" high-fived ")
                .Append(highFivedPeople)
                .Append(AddPlural(highFivedPeople, " other person, ", " other people, "))
                .Append(countByEventType.GetValueOrDefault(ChatEventType.Comment, 0))
                .Append(AddPlural(countByEventType.GetValueOrDefault(ChatEventType.EnterRoom, 0), " comment", " comments"));

            return messageBuilder.ToString();
        }

        /// <summary>
        /// Method creates plural version of the noun
        /// </summary>
        /// <param name="occurrence">Number of occurrences</param>
        /// <param name="singular">Singular version</param>
        /// <param name="plural">Plural version</param>
        /// <returns></returns>
        public static string AddPlural(int occurrence, string singular, string plural)
        {
            return occurrence == 1 ? singular : plural;
        }
    }
}

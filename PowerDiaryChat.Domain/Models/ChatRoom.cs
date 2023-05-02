using PowerDiaryChat.Domain.Enums;
using PowerDiaryChat.Domain.Helpers;

namespace PowerDiaryChat.Domain.Models
{
    public class ChatRoom
    {
        private readonly List<ChatEvent> _events = new();

        public void AddEvent(ChatEvent chatEvent)
        {
            _events.Add(chatEvent);
        }

        public List<ChatEvent> GetEvents()
        {
            return _events;
        }

        public List<HourlyChatEvent> GetAggregatedEvents(DateTime start, DateTime end, TimeSpan granularity)
        {
            var aggregatedChatEvents = new List<HourlyChatEvent>();

            var groupedEvents = _events
                .Where(e => e.Timestamp >= start && e.Timestamp <= end)
                .GroupBy(e => GetTimeSlot(e.Timestamp, granularity));

            foreach (var group in groupedEvents)
            {
                var countByEventType = group
                    .GroupBy(e => e.Type)
                    .ToDictionary(g => g.Key, g => g.Count());

                var countByUser = group
                    .Where(e => e.Type == ChatEventType.HighFive)
                    .GroupBy(e => e.Member)
                    .ToDictionary(g => g.Key, g => g.DistinctBy(x => x.OtherMember).Select(x => x.OtherMember));

                aggregatedChatEvents.Add(
                    new HourlyChatEvent()
                    {
                        Timestamp = group.Key,
                        Message = MessageBuilderHelper.BuildMessage(countByEventType, countByUser)
                    });
            }

            return aggregatedChatEvents;
        }

        private DateTime GetTimeSlot(DateTime timestamp, TimeSpan granularity)
        {
            var ticks = timestamp.Ticks / granularity.Ticks * granularity.Ticks;
            return new DateTime(ticks, timestamp.Kind);
        }
    }
}

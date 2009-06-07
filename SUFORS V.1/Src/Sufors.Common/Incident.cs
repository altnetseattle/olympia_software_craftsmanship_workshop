using System;

namespace Sufors.Common
{
    public class Incident
    {
        public Incident(Message message)
        {
            MessageId = message.Id;
            TimeStamp = message.TimeStamp;
        }
        public int MessageId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Flag { get; set; }

        public bool NotificationRequired()
        {
            return Flag == "urgent" || Flag == "crisis";
        }
    }
}

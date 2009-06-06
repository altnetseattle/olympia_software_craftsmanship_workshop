using System;

namespace Sufors.Common
{
    public class Incident
    {
        public int MessageId { get; set; }
        public int RecorderId { get; set; }
        public DateTime TimeStamp { get; set; }
        public IncidentFlag Flag { get; set; }

        public Incident(Message message, int recorderId)
        {
            MessageId = message.Id;
            TimeStamp = message.TimeStamp;
            RecorderId = recorderId;
        }

        public bool ManagerNotificationRequired()
        {
            return Flag == IncidentFlag.Urgent ||
                Flag == IncidentFlag.Crisis;
        }
    }
}
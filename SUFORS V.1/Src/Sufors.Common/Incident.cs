using System;

namespace Sufors.Common
{
    public class Incident
    {
        public int MessageId { get; set; }
        public DateTime TimeStamp { get; set; }
        public IncidentFlag Flag { get; set; }

        public bool ManagerNotificationRequired()
        {
            return Flag == IncidentFlag.Urgent ||
                Flag == IncidentFlag.Crisis;
        }
    }
}
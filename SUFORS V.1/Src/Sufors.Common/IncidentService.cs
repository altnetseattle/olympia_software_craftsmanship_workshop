
namespace Sufors.Common
{
    public class IncidentService
    {
        INotifier _notifier;

        public IncidentService(INotifier notifier)
        {
            _notifier = notifier;
        }

        public Incident CreateIncidentFromMessage(Message message)
        {
            Incident incident = new Incident();
            incident.MessageId = message.Id;
            incident.TimeStamp = message.TimeStamp;
            return incident;
        }

        public void Save(Incident incident)
        {
            if (incident.Flag == IncidentFlag.Urgent || 
                incident.Flag == IncidentFlag.Crisis)
                _notifier.NotifyManager(incident);
        }
    }
}
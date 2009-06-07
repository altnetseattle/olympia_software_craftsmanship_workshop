
namespace Sufors.Common
{
    public class IncidentService
    {
        INotifier _notifer;

        public IncidentService(INotifier notifier)
        {
            _notifer = notifier;
        }

        public void Save(Incident incident)
        {
            if (incident.NotificationRequired())
                _notifer.NotifyIncidentManager(incident);
        }
    }
}

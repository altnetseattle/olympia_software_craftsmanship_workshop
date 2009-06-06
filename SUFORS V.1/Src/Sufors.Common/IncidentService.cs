
namespace Sufors.Common
{
    public class IncidentService
    {
        INotifier _notifier;

        public IncidentService(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void Save(Incident incident)
        {
            if (incident.ManagerNotificationRequired())
                _notifier.NotifyIncidentManager(incident);
        }
    }
}
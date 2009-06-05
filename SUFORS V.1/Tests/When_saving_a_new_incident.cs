using NUnit.Framework;
using Rhino.Mocks;
using Sufors.Common;

namespace Tests
{
    [TestFixture]
    public class When_saving_a_new_incident_flagged_urgent
    {
        Incident _incident;
        INotifier _notifier;

        [SetUp]
        public void Because()
        {
            _incident = new Incident { Flag = IncidentFlag.Urgent };
            _notifier = MockRepository.GenerateMock<INotifier>();
            IncidentService service = new IncidentService(_notifier);
  
            service.Save(_incident);
        }

        [Test]
        public void Incident_manager_should_be_notified()
        {
            _notifier.AssertWasCalled(notifier => 
                notifier.NotifyManager(_incident));
        }
    }

    [TestFixture]
    public class When_saving_a_new_incident_flagged_crisis
    {
        Incident _incident;
        INotifier _notifier;

        [SetUp]
        public void Because()
        {
            _incident = new Incident { Flag = IncidentFlag.Crisis };
            _notifier = MockRepository.GenerateMock<INotifier>();
            IncidentService service = new IncidentService(_notifier);

            service.Save(_incident);
        }

        [Test]
        public void Incident_manager_should_be_notified()
        {
            _notifier.AssertWasCalled(notifier =>
                notifier.NotifyManager(_incident));
        }
    }
}

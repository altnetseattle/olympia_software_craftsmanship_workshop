using NUnit.Framework;
using Rhino.Mocks;
using Sufors.Common;

namespace Tests
{
    [TestFixture]
    public class When_saving_a_new_incident_flagged_urgent : When_saving_an_incident_context
    {
        [SetUp]
        public override void Because()
        {
            base.Because();
            _incident. Flag = IncidentFlag.Urgent;

            _incidentService.Save(_incident);
        }

        [Test]
        public void Incident_manager_should_be_notified()
        {
            _notifier.AssertWasCalled(notifier =>
                notifier.NotifyIncidentManager(_incident));
        }
    }

    [TestFixture]
    public class When_saving_a_new_incident_flagged_crisis : When_saving_an_incident_context
    {
        [SetUp]
        public override void Because()
        {
            base.Because();
            _incident.Flag = IncidentFlag.Crisis;

            _incidentService.Save(_incident);
        }

        [Test]
        public void Incident_manager_should_be_notified()
        {
            _notifier.AssertWasCalled(notifier =>
                notifier.NotifyIncidentManager(_incident));
        }
    }

    [TestFixture]
    class When_saving_an_incident_flagged_ignore : When_saving_an_incident_context
    {
        [SetUp]
        public override void Because()
        {
            base.Because();
            _incident.Flag = IncidentFlag.Ignore;

            _incidentService.Save(_incident);
        }

        [Test]
        public void Incident_manager_should_not_be_notified()
        {
            _notifier.AssertWasNotCalled(n =>
                n.NotifyIncidentManager(_incident));
        }
    }

    public class When_saving_an_incident_context
    {
        protected INotifier _notifier;
        protected Incident _incident;
        protected IncidentService _incidentService;

        [SetUp]
        public virtual void Because()
        {
            _notifier = MockRepository.GenerateMock<INotifier>();
            _incident = new Incident(new Message(), 12);
            _incidentService = new IncidentService(_notifier);
        }
    }
}

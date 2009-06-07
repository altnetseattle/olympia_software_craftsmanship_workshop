using NUnit.Framework;
using Rhino.Mocks;
using Sufors.Common;

namespace Tests
{
    public class When_saving_a_new_incident_context
    {
        protected INotifier _notifier;
        protected Incident _incident;
        protected IncidentService _incidentService;

        public virtual void Because()
        {
            _notifier = MockRepository.GenerateMock<INotifier>();
            _incident = new Incident(new Message());

            _incidentService = new IncidentService(_notifier);
        }
    }

    [TestFixture]
    public class When_saving_a_new_incident_flagged_urgent : When_saving_a_new_incident_context
    {
        [SetUp]
        public override void Because()
        {
            base.Because();
            _incident.Flag = "urgent";

            _incidentService.Save(_incident);
        }
        [Test]
        public void Incident_manager_should_be_notified()
        {
            _notifier.AssertWasCalled(n =>
                n.NotifyIncidentManager(_incident));
        }
    }

    [TestFixture]
    public class When_saving_a_new_incident_flagged_crisis : When_saving_a_new_incident_context
    {   
        [SetUp]
        public override void Because()
        {
            base.Because();
            _incident.Flag = "crisis";

            _incidentService.Save(_incident);
        }

        [Test]
        public void Incident_manager_should_be_notified()
        {
            _notifier.AssertWasCalled(n =>
                n.NotifyIncidentManager(_incident));
        }
    }

    [TestFixture]
    public class When_saving_a_new_incident_flagged_ignore : When_saving_a_new_incident_context
    {
        [SetUp]
        public override void Because()
        {
            base.Because();
            _incident.Flag = "ignore";

            _incidentService.Save(_incident);
        }

        [Test]
        public void Incident_manager_should_not_be_notified()
        {
            _notifier.AssertWasNotCalled(n =>
                n.NotifyIncidentManager(_incident));
        }
    }
}

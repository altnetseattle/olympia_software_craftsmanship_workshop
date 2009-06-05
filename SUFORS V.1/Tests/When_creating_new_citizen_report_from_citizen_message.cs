using System;
using NUnit.Framework;
using Rhino.Mocks;
using Sufors.Common;

namespace Tests
{
    [TestFixture]
    public class When_creating_new_citizen_report_from_citizen_message
    {
        Message _message;
        Incident _incedent;

        [SetUp]
        public void Because()
        {
            _message = new Message();
            _message.Id = 1;
            _message.TimeStamp = DateTime.Parse("6/1/09");

            INotifier notifier = MockRepository.GenerateMock<INotifier>();
            IncidentService service = new IncidentService(notifier);
            _incedent = service.CreateIncidentFromMessage(_message);
        }

        [Test]
        public void Message_ID_should_be_populated()
        {
            Assert.AreEqual(1, _incedent.MessageId);
        }

        [Test]
        public void Time_stamp_should_be_populated()
        {
            Assert.AreEqual(DateTime.Parse("6/1/09"), _incedent.TimeStamp);
        }
    }
}

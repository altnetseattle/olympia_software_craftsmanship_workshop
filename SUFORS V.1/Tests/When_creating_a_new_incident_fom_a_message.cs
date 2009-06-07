using System;
using NUnit.Framework;
using Sufors.Common;

namespace Tests
{
    [TestFixture]
    public class When_creating_a_new_incident_fom_a_message
    {
        Incident _incident;
        Message _message;

        [SetUp]
        public void Because()
        {
            _message = new Message();
            _message.Id = 1;
            _message.TimeStamp = DateTime.Parse("6/1/09");

            _incident = new Incident(_message);
        }

        [Test]
        public void Message_id_should_be_populated()
        {
            Assert.AreEqual(1, _incident.MessageId);
        }

        [Test]
        public void Time_stamp_should_be_populated()
        {
            Assert.AreEqual(DateTime.Parse("6/1/09"), _incident.TimeStamp);
        }
    }
}

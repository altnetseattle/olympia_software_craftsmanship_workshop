using System;
using NUnit.Framework;
using Sufors.Common;

namespace Tests
{
    [TestFixture]
    public class When_creating_new_incident_from_citizen_message
    {
        Message _message;
        Incident _incedent;

        [SetUp]
        public void Because()
        {
            _message = new Message();
            _message.Id = 1;
            _message.TimeStamp = DateTime.Parse("6/1/09");

            _incedent = new Incident(_message, 1);
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

        public void RecorderId_should_be_populated()
        {
            Assert.AreEqual(12, _incedent.RecorderId);
        }
    }
}

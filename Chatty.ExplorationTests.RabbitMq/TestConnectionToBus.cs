using System;
using Bus.Test.Commands;
using Bus.Test.Commands.Interfaces;
using MassTransit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bus.Test
{
    [TestClass]
    public class TestConnectionToBus
    {
        private bool _received;

        private IBusControl _busControl;

        [TestMethod]
        public void TestConnectionWithBus()
        {
            try
            {
                _busControl = MassTransit.Bus.Factory.CreateUsingRabbitMq(x => x.Host(new Uri("rabbitmq://localhost/"), h => { }));
                _busControl.Start();
            }
            catch (Exception e)
            {
                Assert.Fail("Failed to connect to bus: " + e);
            }
        }

        public void MessageReceived()
        {
            _received = true;
        }

        [TestMethod, Timeout(10000)]
        public void TestMessageSendReceive()
        {
            _busControl = MassTransit.Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(new Uri("rabbitmq://localhost/"), h => { });
                x.ReceiveEndpoint(host, "UnitTests_MessageSendReceive", e =>
                    e.Consumer(() => new PingCommandConsumer(this)));
            });

            _busControl.Start();
            while (!_received)
            {
                _busControl.Publish<IPingCommand>(new PingCommand
                {
                    BoingsCount = 0
                });
            }
            Assert.IsTrue(true);
        }

        [TestMethod, Timeout(10000)]
        public void TestRequestResponse()
        {
            var address = "rabbitmq://localhost/";
            var addressUri = new Uri(address);
            var queue = "UnitTests_MessageRequestResponse";
            _busControl = MassTransit.Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(addressUri, h => { });
                x.ReceiveEndpoint(host, queue, e =>
                    e.Consumer(() => new PingCommandResponder()));
            });

            _busControl.Start();
            var requestTimeout = TimeSpan.FromSeconds(10);
            var queueUri = new Uri(address + queue);
            IRequestClient<IPingRequest, IPingResponse> client =
                new MessageRequestClient<IPingRequest, IPingResponse>(_busControl, queueUri, requestTimeout);
            var response = client.Request(new PingRequest {BoingsCount = 0}).Result;
            Assert.AreEqual(response.BoingsCount, 1);
        }

        [TestCleanup]
        private void CleanUp()
        {
            _busControl?.Stop();
        }
    }
}
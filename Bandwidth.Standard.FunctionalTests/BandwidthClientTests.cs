using System;
using Xunit;

namespace Bandwidth.Standard.FunctionalTests
{
    public class UnitTest1
    {
        [Fact]
        public void ClientShouldThrowWhenMessagingTokenIsNull()
        {
            Action action = () => new BandwidthClient.Builder()
                .Environment(Bandwidth.Standard.Environment.Production)
                .MessagingBasicAuthCredentials(null, "secret")
                .Build();

            var exception = Assert.Throws<ArgumentNullException>(action);

            Assert.Equal("Value cannot be null. (Parameter 'username')", exception.Message);
        }
    }
}

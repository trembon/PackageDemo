using PackageDemo.Services;

namespace PackageDemo.Tests.Services
{
    public class TrackingNumberServiceTests
    {
        [Theory]
        [InlineData("999468372030010241")]
        [InlineData("999468312345678902")]
        public void TryParse_Should_Parse_Valid_Tracking_Numbers(string trackingNumber)
        {
            Fixture fixture = new();

            bool result = fixture.Service.TryParse(trackingNumber, out var parsed);

            Assert.True(result);
            Assert.Equal(trackingNumber, parsed.ToString());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("123451")]
        [InlineData("888468312345678902")]
        [InlineData("8884683I23456789O2")]
        public void TryParse_Should_Fail_When_Rules_Are_Not_Followed(string trackingNumber)
        {
            Fixture fixture = new();

            bool result = fixture.Service.TryParse(trackingNumber, out var parsed);

            Assert.False(result);
            Assert.Equal(-1, parsed);
        }

        [Fact]
        public void GenerateNew_Should_Generate_Valid_Tracking_Number()
        {
            Fixture fixture = new();

            long result = fixture.Service.GenerateNew();

            Assert.True(result > 0);
            Assert.Equal(18, result.ToString().Length);
            Assert.Equal("999", result.ToString()[..3]);
        }

        private class Fixture
        {
            public TrackingNumberService Service { get; }

            public Fixture()
            {
                Service = new TrackingNumberService();
            }
        }
    }
}

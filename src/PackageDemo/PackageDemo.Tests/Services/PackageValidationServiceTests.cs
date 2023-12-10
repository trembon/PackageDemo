using PackageDemo.Context;
using PackageDemo.Services;

namespace PackageDemo.Tests.Services
{
    public class PackageValidationServiceTests
    {
        [Theory]
        [InlineData(0, 1, 1, 1)]
        [InlineData(1, 0, 1, 1)]
        [InlineData(1, 1, 0, 1)]
        [InlineData(1, 1, 1, 0)]
        public void HasValidSize_Checks_Negative_Values_And_Fails(int weight, double length, double height, double width)
        {
            Fixture fixture = new();
            var package = new Package { Weight = weight, Length = length, Height = height, Width = width };

            bool result = fixture.Service.HasValidSize(package);

            Assert.False(result);
        }

        [Theory]
        [InlineData(21000, 1, 1, 1)]
        [InlineData(1, 61, 1, 1)]
        [InlineData(1, 1, 61, 1)]
        [InlineData(1, 1, 1, 61)]
        public void HasValidSize_Checks_Max_Values_And_Fails(int weight, double length, double height, double width)
        {
            Fixture fixture = new();
            var package = new Package { Weight = weight, Length = length, Height = height, Width = width };

            bool result = fixture.Service.HasValidSize(package);

            Assert.False(result);
        }

        [Theory]
        [InlineData(20000, 30, 15, 55)]
        [InlineData(3000, 4, 5, 6)]
        [InlineData(10000, 55, 5, 7)]
        [InlineData(20000, 60, 60, 6)]
        [InlineData(1000, 1, 1, 1)]
        public void HasValidSize_Validates_Packages_Within_Range(int weight, double length, double height, double width)
        {
            Fixture fixture = new();
            var package = new Package { Weight = weight, Length = length, Height = height, Width = width };

            bool result = fixture.Service.HasValidSize(package);

            Assert.True(result);
        }

        private class Fixture
        {
            public PackageValidationService Service { get; }

            public Fixture()
            {
                Service = new PackageValidationService();
            }
        }
    }
}

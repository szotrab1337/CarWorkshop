using Xunit;
using FluentAssertions;

namespace CarWorkshop.Domain.Entities.Tests
{
    public class CarWorkshopTests
    {
        [Fact]
        public void EncodeName_ShouldSetEncodedName()
        {
            // Arrange
            var carWorkshop = new CarWorkshop();
            carWorkshop.Name = "Test Workshop";

            // Act
            carWorkshop.EncodeName();

            // Assert
            carWorkshop.EncodedName.Should().Be("test-workshop");
        }
        
        [Fact]
        public void EncodeName_ShouldThrowException_WhenNameIsNull()
        {
            // Arrange
            var carWorkshop = new CarWorkshop();

            // Act
            var action = () => carWorkshop.EncodeName();

            // Assert
            action.Invoking(x => x.Invoke())
                .Should().Throw<NullReferenceException>();
        }
    }
}
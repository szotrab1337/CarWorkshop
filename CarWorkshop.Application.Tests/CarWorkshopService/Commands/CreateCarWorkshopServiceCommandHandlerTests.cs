using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace CarWorkshop.Application.CarWorkshopService.Commands.Tests
{
    public class CreateCarWorkshopServiceCommandHandlerTests
    {
        [Fact]
        public async Task Handle_CreatesCarWorkshopService_WhenUserIsAuthorized()
        {
            //Arrange
            var carWorkshop = new Domain.Entities.CarWorkshop()
            {
                Id = 1,
                CreatedById = "2"
            };

            var command = new CreateCarWorkshopServiceCommand()
            {
                Cost = "100PLN",
                Description = "Description",
                CarWorkshopEncodedName = "workshop1"
            };

            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(x => x.GetCurrentUser())
                .Returns(new CurrentUser("2", "test@test.com", new[] { "User" }));

            var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
            carWorkshopRepositoryMock.Setup(x => x.GetByEncodedName(command.CarWorkshopEncodedName))
                .ReturnsAsync(carWorkshop);

            var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRepository>();

            var handler = new CreateCarWorkshopServiceCommandHandler(
                userContextMock.Object,
                carWorkshopRepositoryMock.Object,
                carWorkshopServiceRepositoryMock.Object);

            //Act
            await handler.Handle(command, CancellationToken.None);

            //Assert
            carWorkshopServiceRepositoryMock.Verify(x => x.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Once());
        }
        
        [Fact]
        public async Task Handle_CreatesCarWorkshopService_WhenUserIsModerator()
        {
            //Arrange
            var carWorkshop = new Domain.Entities.CarWorkshop()
            {
                Id = 1,
                CreatedById = "2"
            };

            var command = new CreateCarWorkshopServiceCommand()
            {
                Cost = "100PLN",
                Description = "Description",
                CarWorkshopEncodedName = "workshop1"
            };

            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(x => x.GetCurrentUser())
                .Returns(new CurrentUser("5", "test@test.com", new[] { "Moderator" }));

            var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
            carWorkshopRepositoryMock.Setup(x => x.GetByEncodedName(command.CarWorkshopEncodedName))
                .ReturnsAsync(carWorkshop);

            var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRepository>();

            var handler = new CreateCarWorkshopServiceCommandHandler(
                userContextMock.Object,
                carWorkshopRepositoryMock.Object,
                carWorkshopServiceRepositoryMock.Object);

            //Act
            await handler.Handle(command, CancellationToken.None);

            //Assert
            carWorkshopServiceRepositoryMock.Verify(x => x.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Once());
        }
        
        [Fact]
        public async Task Handle_ShouldThrowInvalidOperationException_WhenUserIsNotAuthorized()
        {
            //Arrange
            var carWorkshop = new Domain.Entities.CarWorkshop()
            {
                Id = 1,
                CreatedById = "2"
            };

            var command = new CreateCarWorkshopServiceCommand()
            {
                Cost = "100PLN",
                Description = "Description",
                CarWorkshopEncodedName = "workshop1"
            };

            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(x => x.GetCurrentUser())
                .Returns(new CurrentUser("5", "test@test.com", new[] { "User" }));

            var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
            carWorkshopRepositoryMock.Setup(x => x.GetByEncodedName(command.CarWorkshopEncodedName))
                .ReturnsAsync(carWorkshop);

            var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRepository>();

            var handler = new CreateCarWorkshopServiceCommandHandler(
                userContextMock.Object,
                carWorkshopRepositoryMock.Object,
                carWorkshopServiceRepositoryMock.Object);

            //Act
            var action = async () => await handler.Handle(command, CancellationToken.None);

            //Assert
            await action.Should().ThrowAsync<InvalidOperationException>();
            carWorkshopServiceRepositoryMock.Verify(x => x.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Never());
        }
        
        [Fact]
        public async Task Handle_ShouldThrowInvalidOperationException_WhenUserIsNotAuthenticated()
        {
            //Arrange
            var carWorkshop = new Domain.Entities.CarWorkshop()
            {
                Id = 1,
                CreatedById = "2"
            };

            var command = new CreateCarWorkshopServiceCommand()
            {
                Cost = "100PLN",
                Description = "Description",
                CarWorkshopEncodedName = "workshop1"
            };

            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(x => x.GetCurrentUser())
                .Returns((CurrentUser?)null);

            var carWorkshopRepositoryMock = new Mock<ICarWorkshopRepository>();
            carWorkshopRepositoryMock.Setup(x => x.GetByEncodedName(command.CarWorkshopEncodedName))
                .ReturnsAsync(carWorkshop);

            var carWorkshopServiceRepositoryMock = new Mock<ICarWorkshopServiceRepository>();

            var handler = new CreateCarWorkshopServiceCommandHandler(
                userContextMock.Object,
                carWorkshopRepositoryMock.Object,
                carWorkshopServiceRepositoryMock.Object);

            //Act
            var action = async () => await handler.Handle(command, CancellationToken.None);

            //Assert
            await action.Should().ThrowAsync<InvalidOperationException>();
            carWorkshopServiceRepositoryMock.Verify(x => x.Create(It.IsAny<Domain.Entities.CarWorkshopService>()), Times.Never());
        }
    }
}
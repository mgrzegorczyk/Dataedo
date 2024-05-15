using Bogus;
using Dataedo.Application.Commands;
using Dataedo.Infrastructure.Repositories;
using Moq;
using Xunit;

namespace Dataedo.Tests
{
    public class DeleteUserCommandHandlerTests
    {
        private readonly Mock<IUsersRepository> _usersRepositoryMock;
        private readonly DeleteUserCommandHandler _handler;
        private readonly Faker _faker;

        public DeleteUserCommandHandlerTests()
        {
            _usersRepositoryMock = new Mock<IUsersRepository>();
            _handler = new DeleteUserCommandHandler(_usersRepositoryMock.Object);
            _faker = new Faker();
        }

        [Fact]
        public async Task Handle_Should_Call_DeleteAsync_On_Repository()
        {
            // Arrange
            var userId = _faker.Random.Guid();
            var command = new DeleteUserCommand(userId);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _usersRepositoryMock.Verify(repo => repo.DeleteAsync(userId), Times.Once);
        }
    }
}
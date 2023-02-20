using Microsoft.Extensions.Logging;
using Moq;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;
using OOPVotingSystem.Service;
using OOPVotingSystem.Service.Abstractions;

namespace OOPVotingSystem.Tests.Unit.Services;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepository = new Mock<IUserRepository>();

    private readonly Mock<IPersonRepository> _mockPersonRepository = new Mock<IPersonRepository>();

    private readonly Mock<ILogger<UserService>> _mockLogger = new Mock<ILogger<UserService>>();

    private User GetUser()
    {
        return new User
        {
            PersonId = Guid.NewGuid().ToString(),
            Username = "testUser",
            Password = "password123",
        };
    }

    [Fact]
    public async Task SuccessfullyLogIn_WhenAUserExists()
    {
        // Arrange
        _ = _mockUserRepository
            .Setup(t => t.GetUserByUsername(It.IsAny<string>()))
            .ReturnsAsync(GetUser());

        IUserService sut = new UserService(
            _mockLogger.Object,
            _mockUserRepository.Object,
            _mockPersonRepository.Object);

        // Act
        bool response = await sut.Login("testUser", "password123");

        // Assert
        Assert.True(response);
    }

    [Fact]
    public async Task LogInFails_WhenAUsersPasswordIsIncorrect()
    {
        // Arrange
        _ = _mockUserRepository
            .Setup(t => t.GetUserByUsername(It.IsAny<string>()))
            .ReturnsAsync(GetUser());

        IUserService sut = new UserService(_mockLogger.Object, _mockUserRepository.Object);

        // Act
        bool response = await sut.Login("testUser", "password124");

        // Assert
        Assert.False(response);
    }
}

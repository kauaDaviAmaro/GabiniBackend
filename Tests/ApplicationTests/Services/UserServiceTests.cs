using Moq;
using Core.Models;
using Core.Repositories;
using Application.Services;
using Core.DTOs;

namespace Test.Application.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task SaveUser_ShouldCallRepositoryAndReturnUser()
        {
            // Arrange
            Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
            User user = new User("John Doe", "johndoe", "johndoe@example.com", "123456789", new DateTime(1990, 1, 1).ToString("dd/MM/yyyy"), Gender.Male, "12345678901", MaritalStatus.Single, Scholarship.Bachelor, "password123");
            mockRepository.Setup(r => r.SaveUser(It.IsAny<User>())).ReturnsAsync(user);

            UserService service = new UserService(mockRepository.Object);
            UserDTO userDTO = new UserDTO("John Doe", "johndoe", "johndoe@example.com", "123456789", new DateTime(1990, 1, 1).ToString("dd/MM/yyyy"), Gender.Male, "12345678901", MaritalStatus.Single, Scholarship.Bachelor, "password123");

            // Act
            User result = await service.SaveUser(userDTO);

            // Assert
            mockRepository.Verify(r => r.SaveUser(It.IsAny<User>()), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task UpdateUser_ShouldCallRepositoryAndReturnUpdatedUser()
        {
            // Arrange
            Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
            string userId = "1";
            User existingUser = new User("John Doe", "johndoe", "johndoe@example.com", "123456789", new DateTime(1990, 1, 1).ToString("dd/MM/yyyy"), Gender.Male, "12345678901", MaritalStatus.Single, Scholarship.Bachelor, "password123");
            UserDTO updatedUserDTO = new UserDTO("John Doe", "johndoe", "john.doe@example.com", "987654321", new DateTime(1990, 1, 1).ToString("dd/MM/yyyy"), Gender.Male, "12345678901", MaritalStatus.Single, Scholarship.Bachelor, "newpassword123");

            mockRepository.Setup(r => r.GetUser(userId)).ReturnsAsync(existingUser);
            mockRepository.Setup(r => r.UpdateUser(It.IsAny<User>())).ReturnsAsync(existingUser);

            UserService service = new UserService(mockRepository.Object);

            // Act
            User result = await service.UpdateUser(userId, updatedUserDTO);

            // Assert
            mockRepository.Verify(r => r.GetUser(userId), Times.Once);
            mockRepository.Verify(r => r.UpdateUser(It.IsAny<User>()), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(existingUser.Email, result.Email); // Check if the email is updated
        }

        [Fact]
        public async Task GetUser_ShouldCallRepositoryAndReturnUser()
        {
            // Arrange
            Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
            string userId = "1";
            User expectedUser = new User("John Doe", "johndoe", "johndoe@example.com", "123456789", new DateTime(1990, 1, 1).ToString("dd/MM/yyyy"), Gender.Male, "12345678901", MaritalStatus.Single, Scholarship.Bachelor, "password123");

            mockRepository.Setup(r => r.GetUser(userId)).ReturnsAsync(expectedUser);

            UserService service = new UserService(mockRepository.Object);

            // Act
            User? result = await service.GetUser(userId);

            // Assert
            mockRepository.Verify(r => r.GetUser(userId), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(expectedUser, result);
        }


    }
}
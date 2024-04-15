using Formula1WebApplication.Core.Models.User;
using Formula1WebApplication.Core.Services;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using MockQueryable.Moq;
using Moq;

namespace Formula1WebApplication.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IRepository> mockRepository;
        private UserService userService;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IRepository>();
            userService = new UserService(mockRepository.Object);

            var users = new List<ApplicationUser>
            {
                new ApplicationUser {
                    Id = "1", Email = "user1@example.com", FirstName = "John", LastName = "Doe",
                    Organizer = new Organizer { PhoneNumber = "1234567890" }
                },
                new ApplicationUser {
                    Id = "2", Email = "user2@example.com", FirstName = "Jane", LastName = "Smith",
                    Organizer = null
                }
            }.AsQueryable();

            var mockUsers = users.BuildMockDbSet();
            mockRepository.Setup(r => r.AllReadOnly<ApplicationUser>()).Returns(mockUsers.Object);
        }

        [Test]
        public async Task GetUserFullNameAsync_ExistingUser_ReturnsFullName()
        {
            string userId = "1"; 
            var expectedUser = new ApplicationUser
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe"
            };

            mockRepository.Setup(r => r.GetByIdAsync<ApplicationUser>(It.Is<string>(id => id == userId)))
                          .ReturnsAsync(expectedUser);

            var result = await userService.GetUserFullNameAsync(userId);

            Assert.IsNotNull(result, "The result should not be null for an existing user.");
            Assert.That(result, Is.EqualTo("John Doe"), "The full name should match the expected value.");
        }

        [Test]
        public async Task GetUserFullNameAsync_NonExistingUser_ReturnsEmptyString()
        {
            string userId = "3"; 
            ApplicationUser? nullUser = null;

            mockRepository.Setup(r => r.GetByIdAsync<ApplicationUser>(It.Is<string>(id => id == userId)))
                          .ReturnsAsync(nullUser);

            var result = await userService.GetUserFullNameAsync(userId);

            Assert.IsEmpty(result, "The result should be an empty string for a non-existing user.");
        }

        [Test]
        public async Task AllUsersAsync_ReturnsAllUsers()
        {
            var expectedUsers = new List<UserServiceModel>
            {
                new UserServiceModel {
                    Email = "user1@example.com",
                    FullName = "John Doe",
                    PhoneNumber = "1234567890",
                    IsOrganizer = true
                },
                new UserServiceModel {
                    Email = "user2@example.com",
                    FullName = "Jane Smith",
                    PhoneNumber = null,
                    IsOrganizer = false
                }
            };

            var result = await userService.AllUsersAsync();

            Assert.IsNotNull(result, "Result should not be null.");
            Assert.That(result.Count(), Is.EqualTo(2), "Should return exactly two users.");
            Assert.That(result.ElementAt(0).Email, Is.EqualTo(expectedUsers[0].Email), "Email should match for the first user.");
            Assert.That(result.ElementAt(0).FullName, Is.EqualTo(expectedUsers[0].FullName), "FullName should match for the first user.");
            Assert.That(result.ElementAt(0).PhoneNumber, Is.EqualTo(expectedUsers[0].PhoneNumber), "PhoneNumber should match for the first user.");
            Assert.That(result.ElementAt(0).IsOrganizer, Is.EqualTo(expectedUsers[0].IsOrganizer), "IsOrganizer should match for the first user.");

            Assert.That(result.ElementAt(1).Email, Is.EqualTo(expectedUsers[1].Email), "Email should match for the second user.");
            Assert.That(result.ElementAt(1).FullName, Is.EqualTo(expectedUsers[1].FullName), "FullName should match for the second user.");
            Assert.That(result.ElementAt(1).PhoneNumber, Is.EqualTo(expectedUsers[1].PhoneNumber), "PhoneNumber should match for the second user.");
            Assert.That(result.ElementAt(1).IsOrganizer, Is.EqualTo(expectedUsers[1].IsOrganizer), "IsOrganizer should match for the second user.");
        }
    }
}

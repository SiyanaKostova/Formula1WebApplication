using Formula1WebApplication.Core.Services;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using MockQueryable.Moq;
using Moq;

namespace Formula1WebApplication.Tests
{
    [TestFixture]
    public class OrganizerServiceTests
    {
        private Mock<IRepository> mockRepository;
        private OrganizerService organizerService;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IRepository>();

            organizerService = new OrganizerService(mockRepository.Object);

            var organizers = new List<Organizer>
            {
                new Organizer { Id = 1, UserId = "user1", PhoneNumber = "1234567890" },
                new Organizer { Id = 2, UserId = "user2", PhoneNumber = "0987654321" }
            };

            var mockOrganizers = organizers.AsQueryable().BuildMockDbSet();

            mockRepository.Setup(r => r.AllReadOnly<Organizer>()).Returns(mockOrganizers.Object);
            mockRepository.Setup(r => r.All<Organizer>()).Returns(mockOrganizers.Object);
            mockRepository.Setup(r => r.AddAsync(It.IsAny<Organizer>())).Returns(Task.CompletedTask);
            mockRepository.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);
        }

        [Test]
        public async Task IsUserAlreadyOrganizerAsync_UserIsOrganizer_ReturnsTrue()
        {
            var result = await organizerService.IsUserAlreadyOrganizerAsync("user1");
            Assert.IsTrue(result, "The user should already be an organizer.");
        }

        [Test]
        public async Task IsUserAlreadyOrganizerAsync_UserIsNotOrganizer_ReturnsFalse()
        {
            var result = await organizerService.IsUserAlreadyOrganizerAsync("user3");
            Assert.IsFalse(result, "The user should not be an organizer.");
        }

        [Test]
        public async Task IsPhoneNumberAlreadyUsedAsync_ExistingPhoneNumber_ReturnsTrue()
        {
            var phoneNumber = "1234567890";
            var result = await organizerService.IsPhoneNumberAlreadyUsedAsync(phoneNumber);
            Assert.IsTrue(result, "Should return true for a phone number that is already used.");
        }

        [Test]
        public async Task IsPhoneNumberAlreadyUsedAsync_NonExistingPhoneNumber_ReturnsFalse()
        {
            var phoneNumber = "0000000000";
            var result = await organizerService.IsPhoneNumberAlreadyUsedAsync(phoneNumber);
            Assert.IsFalse(result, "Should return false for a phone number that is not used.");
        }

        [Test]
        public async Task BecomeOrganizerAsync_UserOrPhoneNumberExists_ReturnsFalse()
        {
            string existingUserId = "user1";
            string existingPhoneNumber = "1234567890";

            bool resultUserId = await organizerService.BecomeOrganizerAsync(existingUserId, "newPhoneNumber");
            bool resultPhoneNumber = await organizerService.BecomeOrganizerAsync("newUserId", existingPhoneNumber);

            Assert.IsFalse(resultUserId, "Should return false when the user is already an organizer.");
            Assert.IsFalse(resultPhoneNumber, "Should return false when the phone number is already used.");
        }

        [Test]
        public async Task BecomeOrganizerAsync_UserAndPhoneNumberNew_ReturnsTrueAndAddsOrganizer()
        {
            string newUserId = "newUser";
            string newPhoneNumber = "0000000000";

            mockRepository.Setup(r => r.AddAsync(It.IsAny<Organizer>()))
                          .Callback<Organizer>(org =>
                          {
                              Assert.That(org.UserId, Is.EqualTo(newUserId));
                              Assert.That(org.PhoneNumber, Is.EqualTo(newPhoneNumber));
                          })
                          .Returns(Task.CompletedTask);

            bool result = await organizerService.BecomeOrganizerAsync(newUserId, newPhoneNumber);

            Assert.IsTrue(result, "Should return true when adding a new organizer with new user ID and phone number.");
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once, "SaveChangesAsync should be called once to save the new organizer.");
        }

        [Test]
        public async Task GetOrganizerIdAsync_ExistingUserId_ReturnsCorrectId()
        {
            string userId = "user1";
            int expectedId = 1;

            int? result = await organizerService.GetOrganizerIdAsync(userId);

            Assert.IsNotNull(result, "Result should not be null for an existing user.");
            Assert.That(result, Is.EqualTo(expectedId), "Should return the correct organizer ID for the existing user.");
        }

        [Test]
        public async Task GetOrganizerIdAsync_NonExistingUserId_ReturnsNull()
        {
            string nonExistingUserId = "nonExistingUser";

            int? result = await organizerService.GetOrganizerIdAsync(nonExistingUserId);

            Assert.IsNull(result, "Should return null for a non-existing user ID.");
        }

        [Test]
        public async Task ExistsByIdAsync_ExistingUserId_ReturnsTrue()
        {
            string userId = "user1";

            bool exists = await organizerService.ExistsByIdAsync(userId);

            Assert.IsTrue(exists, "Should return true for an existing organizer user ID.");
        }

        [Test]
        public async Task ExistsByIdAsync_NonExistingUserId_ReturnsFalse()
        {
            string nonExistingUserId = "user3"; 

            bool exists = await organizerService.ExistsByIdAsync(nonExistingUserId);

            Assert.IsFalse(exists, "Should return false for a non-existing organizer user ID.");
        }
    }
}

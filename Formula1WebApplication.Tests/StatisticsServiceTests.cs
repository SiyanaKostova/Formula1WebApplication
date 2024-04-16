using Formula1WebApplication.Core.Services;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using MockQueryable.Moq;
using Moq;

namespace Formula1WebApplication.Tests
{
    [TestFixture]
    public class StatisticsServiceTests
    {
        private Mock<IRepository> mockRepository;
        private StatisticsService statisticsService;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IRepository>();

            var mockPilots = new List<Pilot>
            {
                 new Pilot { Id = 1, FirstName = "Lewis", LastName = "Hamilton", Nationality = "British", TeamName = "Mercedes", Biography = "Biography 1", ImagePath = "image1.jpg" },
                new Pilot { Id = 2, FirstName = "Max", LastName = "Verstappen", Nationality = "Dutch", TeamName = "Red Bull Racing", Biography = "Biography 2", ImagePath = "image2.jpg" },
                new Pilot { Id = 3, FirstName = "Fernando", LastName = "Alonso", Nationality = "Spanish", TeamName = "Alpine", Biography = "Biography 3", ImagePath = "image3.jpg" }
            }.AsQueryable().BuildMockDbSet();
            mockRepository.Setup(r => r.AllReadOnly<Pilot>()).Returns(mockPilots.Object);

            var mockNewsArticles = new List<NewsArticle>
            {
                new NewsArticle { Id = 1, Title = "First Article", Description = "Description 1", ImageUrl = "URL1" },
                new NewsArticle { Id = 2, Title = "Second Article", Description = "Description 2", ImageUrl = "URL2" },
                new NewsArticle { Id = 3, Title = "Third Article", Description = "Description 3", ImageUrl = "URL3" },
                new NewsArticle { Id = 4, Title = "Fourth Article", Description = "Description 4", ImageUrl = "URL4" }
            }.AsQueryable().BuildMockDbSet();
            mockRepository.Setup(r => r.AllReadOnly<NewsArticle>()).Returns(mockNewsArticles.Object);

            var mockEvents = new List<Event>
            {
                new Event { Id = 3, Name = "Event C", Description = "Third Event", ImageUrl = "ImageUrl3", Location = "Location3", Date = DateTime.Now },
                new Event { Id = 2, Name = "Event B", Description = "Second Event", ImageUrl = "ImageUrl2", Location = "Location2", Date = DateTime.Now },
                new Event { Id = 1, Name = "Event A", Description = "First Event", ImageUrl = "ImageUrl1", Location = "Location1", Date = DateTime.Now }
            }.AsQueryable().BuildMockDbSet();
            mockRepository.Setup(r => r.AllReadOnly<Event>()).Returns(mockEvents.Object);

            var mockRaces = new List<Race>
            {
                new Race { Id = 1, Name = "Grand Prix A", CircuitInfo = "Circuit A", Date = DateTime.Now, Location = "Location A", Laps = 58, ImageUrl = "http://imageA.url", OrganizerId = 1 },
                new Race { Id = 2, Name = "Grand Prix B", CircuitInfo = "Circuit B", Date = DateTime.Now, Location = "Location B", Laps = 60, ImageUrl = "http://imageB.url", OrganizerId = 1 }
            }.AsQueryable().BuildMockDbSet();
            mockRepository.Setup(r => r.AllReadOnly<Race>()).Returns(mockRaces.Object);

            var mockOrganizers = new List<Organizer>
            {
                new Organizer { Id = 1, UserId = "user1", PhoneNumber = "1234567890" },
                new Organizer { Id = 2, UserId = "user2", PhoneNumber = "0987654321" }
            }.AsQueryable().BuildMockDbSet();
            mockRepository.Setup(r => r.AllReadOnly<Organizer>()).Returns(mockOrganizers.Object);

            statisticsService = new StatisticsService(mockRepository.Object);
        }

        [Test]
        public async Task TotalAsync_ReturnsCorrectStatistics()
        {
            var result = await statisticsService.TotalAsync();

            Assert.That(result.TotalPilots, Is.EqualTo(3)); 
            Assert.That(result.TotalNewsArticles, Is.EqualTo(4));
            Assert.That(result.TotalEvents, Is.EqualTo(3));
            Assert.That(result.TotalRaces, Is.EqualTo(2));
            Assert.That(result.TotalOrganizers, Is.EqualTo(2));
        }
    }
}

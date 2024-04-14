using Formula1WebApplication.Core.Services;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using MockQueryable.Moq;
using Moq;

namespace Formula1WebApplication.Tests
{
    [TestFixture]
    public class PilotServiceTests
    {
        private Mock<IRepository> mockRepository;
        private PilotService pilotService;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IRepository>();
            pilotService = new PilotService(mockRepository.Object);

            var pilots = new List<Pilot>
            {
                new Pilot { Id = 1, FirstName = "Lewis", LastName = "Hamilton", Nationality = "British", TeamName = "Mercedes", Biography = "Biography 1", ImagePath = "image1.jpg" },
                new Pilot { Id = 2, FirstName = "Max", LastName = "Verstappen", Nationality = "Dutch", TeamName = "Red Bull Racing", Biography = "Biography 2", ImagePath = "image2.jpg" },
                new Pilot { Id = 3, FirstName = "Fernando", LastName = "Alonso", Nationality = "Spanish", TeamName = "Alpine", Biography = "Biography 3", ImagePath = "image3.jpg" }
            };

            var mockPilots = pilots.AsQueryable().BuildMockDbSet();
            mockRepository.Setup(r => r.All<Pilot>()).Returns(mockPilots.Object);
            mockRepository.Setup(r => r.AllReadOnly<Pilot>()).Returns(mockPilots.Object);
        }

        [Test]
        public async Task GetAllPilotsAsync_WithFiltersAndSorting_ReturnsFilteredSortedAndPaginatedResults()
        {
            string searchTerm = "Max";
            string nationalityFilter = "Dutch";
            string teamFilter = "Red Bull Racing";
            string sortOrder = "firstName_desc";
            int pageIndex = 1;
            int pageSize = 2; 

            var result = await pilotService.GetAllPilotsAsync(
                searchTerm,
                nationalityFilter,
                teamFilter,
                sortOrder,
                pageIndex,
                pageSize);

            Assert.That(result.Pilots.TotalCount, Is.EqualTo(1), "Should match the expected number of filtered results.");
            Assert.That(result.Pilots.TotalPages, Is.EqualTo(1), "Should correctly calculate the total number of pages.");
            Assert.That(result.Pilots.PageIndex, Is.EqualTo(pageIndex), "Should return the correct page index.");
            Assert.That(result.Pilots.PageSize, Is.EqualTo(pageSize), "Should return the correct page size.");
            Assert.That(result.SearchTerm, Is.EqualTo(searchTerm), "Should return the correct search term.");
            Assert.That(result.NationalityFilter, Is.EqualTo(nationalityFilter), "Should return the correct nationality filter.");
            Assert.That(result.TeamFilter, Is.EqualTo(teamFilter), "Should return the correct team filter.");
            Assert.That(result.SortOrder, Is.EqualTo(sortOrder), "Should return the correct sort order.");
            Assert.IsTrue(result.Pilots.First().FirstName.Contains("Max"), "The first item should be the one filtered by the search term and sorted descending by first name.");
        }

        [Test]
        public async Task GetDetailsAsync_GivenValidId_ReturnsPilotDetails()
        {
            int pilotId = 2; 

            var result = await pilotService.GetDetailsAsync(pilotId);

            Assert.IsNotNull(result, "The result should not be null for an existing pilot ID.");
            Assert.That(result.Id, Is.EqualTo(pilotId), "The ID should match the requested pilot ID.");
            Assert.That(result.FirstName, Is.EqualTo("Max"), "The FirstName should match the pilot's first name.");
            Assert.That(result.LastName, Is.EqualTo("Verstappen"), "The LastName should match the pilot's last name.");
            Assert.That(result.Nationality, Is.EqualTo("Dutch"), "The Nationality should match the pilot's nationality.");
            Assert.That(result.TeamName, Is.EqualTo("Red Bull Racing"), "The TeamName should match the pilot's team name.");
            Assert.That(result.Biography, Is.EqualTo("Biography 2"), "The Biography should match the pilot's biography.");
            Assert.That(result.ImagePath, Is.EqualTo("image2.jpg"), "The ImagePath should match the pilot's image path.");
        }

        [Test]
        public async Task GetDetailsAsync_GivenInvalidId_ReturnsNull()
        {
            int invalidPilotId = 99; 

            var result = await pilotService.GetDetailsAsync(invalidPilotId);

            Assert.IsNull(result, "The result should be null for a non-existing pilot ID.");
        }
    }
}

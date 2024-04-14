using Formula1WebApplication.Core.Contracts;
using Formula1WebApplication.Core.Models.Race;
using Formula1WebApplication.Core.Services;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using MockQueryable.Moq;
using Moq;

namespace Formula1WebApplication.Tests
{
    [TestFixture]
    public class RaceServiceTests
    {
        private Mock<IRepository> mockRepository;
        private IRaceService raceService;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IRepository>();
            raceService = new RaceService(mockRepository.Object);

            var races = new List<Race>
            {
                new Race { Id = 1, Name = "Grand Prix A", CircuitInfo = "Circuit A", Date = DateTime.Now, Location = "Location A", Laps = 58, ImageUrl = "http://imageA.url", OrganizerId = 1 },
                new Race { Id = 2, Name = "Grand Prix B", CircuitInfo = "Circuit B", Date = DateTime.Now, Location = "Location B", Laps = 60, ImageUrl = "http://imageB.url", OrganizerId = 1 },
            }.AsQueryable();

            var mockRacesDbSet = races.BuildMockDbSet();

            mockRepository.Setup(r => r.All<Race>()).Returns(mockRacesDbSet.Object);
            mockRepository.Setup(r => r.AllReadOnly<Race>()).Returns(mockRacesDbSet.Object);
        }

        [Test]
        public async Task AddAsync_ShouldAddRace_AndSaveChanges()
        {
            var newRaceModel = new RaceServiceModel
            {
                Name = "New Grand Prix",
                CircuitInfo = "New Circuit",
                Date = DateTime.UtcNow,
                Location = "New Location",
                Laps = 70,
                ImageUrl = "http://newrace.url"
            };
            int organizerId = 1;

            await raceService.AddAsync(newRaceModel, organizerId);

            mockRepository.Verify(r => r.AddAsync(It.Is<Race>(race =>
                race.Name == newRaceModel.Name &&
                race.CircuitInfo == newRaceModel.CircuitInfo &&
                race.Date == newRaceModel.Date &&
                race.Location == newRaceModel.Location &&
                race.Laps == newRaceModel.Laps &&
                race.ImageUrl == newRaceModel.ImageUrl &&
                race.OrganizerId == organizerId
            )), Times.Once);

            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task GetAllRacesAsync_ReturnsPaginatedSortedFilteredResults()
        {
            const string searchTerm = "Grand Prix";
            const string sortOrder = "name_desc";
            const int pageIndex = 1;
            const int pageSize = 2;

            var races = new List<Race>
            {
                new Race { Id = 3, Name = "Monaco Grand Prix", CircuitInfo = "Circuit de Monaco", Date = DateTime.Now, Location = "Monaco", Laps = 78, ImageUrl = "http://monaco.image.url" },
                new Race { Id = 2, Name = "British Grand Prix", CircuitInfo = "Silverstone Circuit", Date = DateTime.Now, Location = "Silverstone", Laps = 52, ImageUrl = "http://british.image.url" },
                new Race { Id = 1, Name = "Australian Grand Prix", CircuitInfo = "Albert Park Circuit", Date = DateTime.Now, Location = "Melbourne", Laps = 58, ImageUrl = "http://australian.image.url" },
            };

            var queryableRaces = races.AsQueryable();
            var mockRacesDbSet = queryableRaces.BuildMockDbSet();

            mockRepository.Setup(r => r.All<Race>()).Returns(mockRacesDbSet.Object);

            var result = await raceService.GetAllRacesAsync(searchTerm, sortOrder, pageIndex, pageSize);

            Assert.That(result.TotalCount, Is.EqualTo(queryableRaces.Count()), "TotalItems should match the number of races after filtering.");
            Assert.That(result.First().Name, Is.EqualTo("Monaco Grand Prix"), "The first item should be the 'Monaco Grand Prix' given the sort order.");
            Assert.That(result.PageIndex, Is.EqualTo(pageIndex), "PageIndex should match the requested page index.");
            Assert.That(result.TotalPages, Is.EqualTo((int)Math.Ceiling((double)queryableRaces.Count() / pageSize)), "TotalPages should be correctly calculated based on page size.");
            Assert.That(result.All(r => r.Name.Contains(searchTerm)), Is.True, "All items should contain the search term.");
            Assert.That(result, Is.Ordered.Descending.By(nameof(RaceServiceModel.Name)), "Items should be ordered by name in descending order.");
        }

        [Test]
        public async Task GetDetailsAsync_WithValidId_ReturnsRaceDetails()
        {
            var raceId = 1; 
            var expectedRace = new Race
            {
                Id = raceId,
                Name = "Grand Prix A",
                CircuitInfo = "Circuit A",
                Date = new DateTime(2022, 4, 10),
                Location = "Location A",
                Laps = 58,
                ImageUrl = "http://imageA.url",
                OrganizerId = 1
            };

            mockRepository.Setup(repo => repo.AllReadOnly<Race>())
                          .Returns(new List<Race> { expectedRace }.AsQueryable().BuildMockDbSet().Object);

            var result = await raceService.GetDetailsAsync(raceId);

            Assert.IsNotNull(result, "Result should not be null for an existing race ID.");
            Assert.That(result.Id, Is.EqualTo(expectedRace.Id), "Race ID should match the search ID.");
            Assert.That(result.Name, Is.EqualTo(expectedRace.Name), "Race Name should match.");
            Assert.That(result.CircuitInfo, Is.EqualTo(expectedRace.CircuitInfo), "Race CircuitInfo should match.");
            Assert.That(result.Date, Is.EqualTo(expectedRace.Date), "Race Date should match.");
            Assert.That(result.Location, Is.EqualTo(expectedRace.Location), "Race Location should match.");
            Assert.That(result.Laps, Is.EqualTo(expectedRace.Laps), "Race Laps should match.");
            Assert.That(result.ImageUrl, Is.EqualTo(expectedRace.ImageUrl), "Race ImageUrl should match.");
        }

        [Test]
        public async Task EditAsync_ExistingRaceId_UpdatesRace()
        {
            int raceId = 1; 

            var updatedRaceModel = new RaceServiceModel
            {
                Id = raceId,
                Name = "Updated Grand Prix A",
                CircuitInfo = "Updated Circuit A",
                Date = new DateTime(2023, 4, 10),
                Location = "Updated Location A",
                Laps = 59,
                ImageUrl = "http://updatedimageA.url"
            };

            var race = new Race
            {
                Id = raceId,
                Name = "Grand Prix A",
                CircuitInfo = "Circuit A",
                Date = DateTime.Now,
                Location = "Location A",
                Laps = 58,
                ImageUrl = "http://imageA.url",
                OrganizerId = 1
            };

            mockRepository.Setup(repo => repo.GetByIdAsync<Race>(It.IsAny<int>())).ReturnsAsync(race);
            mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(1);

            await raceService.EditAsync(raceId, updatedRaceModel);

            mockRepository.Verify(repo => repo.GetByIdAsync<Race>(It.Is<int>(id => id == raceId)), Times.Once);
            mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);

            Assert.That(race.Name, Is.EqualTo(updatedRaceModel.Name), "Race name should be updated.");
            Assert.That(race.CircuitInfo, Is.EqualTo(updatedRaceModel.CircuitInfo), "Race circuit info should be updated.");
            Assert.That(race.Date, Is.EqualTo(updatedRaceModel.Date), "Race date should be updated.");
            Assert.That(race.Location, Is.EqualTo(updatedRaceModel.Location), "Race location should be updated.");
            Assert.That(race.Laps, Is.EqualTo(updatedRaceModel.Laps), "Race laps should be updated.");
            Assert.That(race.ImageUrl, Is.EqualTo(updatedRaceModel.ImageUrl), "Race image URL should be updated.");
        }

        [Test]
        public async Task HasOrganizerWithIdAsync_WithExistingRaceAndOrganizer_ReturnsTrue()
        {
            int raceId = 1; 
            string userId = "existing-organizer-userId"; 

            var organizer = new Organizer { UserId = userId }; 
            var race = new Race { Id = raceId, Organizer = organizer };
            var races = new List<Race> { race }.AsQueryable();

            var mockRacesDbSet = races.BuildMockDbSet();
            mockRepository.Setup(repo => repo.AllReadOnly<Race>()).Returns(mockRacesDbSet.Object);

            bool hasOrganizer = await raceService.HasOrganizerWithIdAsync(raceId, userId);

            Assert.IsTrue(hasOrganizer, "Should return true if the race is organized by the user with the given ID.");
        }

        [Test]
        public async Task GetRaceServiceModelByIdAsync_ExistingId_ReturnsRaceDetails()
        {
            int searchId = 1;

            var races = new List<Race>
            {
                new Race { Id = 1, Name = "Grand Prix A", CircuitInfo = "Circuit A", Date = DateTime.Now, Location = "Location A", Laps = 58, ImageUrl = "http://imageA.url" },
                new Race { Id = 2, Name = "Grand Prix B", CircuitInfo = "Circuit B", Date = DateTime.Now, Location = "Location B", Laps = 60, ImageUrl = "http://imageB.url" }
            }.AsQueryable();

            var mockRacesDbSet = races.BuildMockDbSet();
            mockRepository.Setup(r => r.AllReadOnly<Race>()).Returns(mockRacesDbSet.Object);

            var result = await raceService.GetRaceServiceModelByIdAsync(searchId);

            Assert.IsNotNull(result, "Result should not be null for an existing race ID.");
            Assert.That(result.Id, Is.EqualTo(searchId), "Race ID should match the search ID.");
            Assert.That(result.Name, Is.EqualTo("Grand Prix A"), "Race Name should match the expected value.");
            Assert.That(result.Location, Is.EqualTo("Location A"), "Race Location should match the expected value.");
            Assert.That(result.ImageUrl, Is.EqualTo("http://imageA.url"), "Race ImageUrl should match the expected value.");
            Assert.That(result.Laps, Is.EqualTo(58), "Race Laps should match the expected value.");
            Assert.That(result.CircuitInfo, Is.EqualTo("Circuit A"), "Race CircuitInfo should match the expected value.");
        }

        [Test]
        public async Task DeleteAsync_ExistingRaceId_DeletesRaceAndSavesChanges()
        {
            int raceIdToDelete = 1; 

            mockRepository.Setup(r => r.DeleteAsync<Race>(It.IsAny<object>()))
                .Callback((object id) =>
                {
                    Assert.That(id, Is.EqualTo(raceIdToDelete), "Should delete the race with the correct ID.");
                })
                .Returns(Task.CompletedTask);

            mockRepository.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

            await raceService.DeleteAsync(raceIdToDelete);

            mockRepository.Verify(r => r.DeleteAsync<Race>(It.IsAny<object>()), Times.Once, "Method DeleteAsync was not called exactly once.");
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once, "Method SaveChangesAsync was not called exactly once.");
        }
    }
}

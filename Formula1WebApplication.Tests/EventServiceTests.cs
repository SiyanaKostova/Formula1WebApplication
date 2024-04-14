using Formula1WebApplication.Core.Models.Event;
using Formula1WebApplication.Core.Services;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using System.Linq.Expressions;
using Event = Formula1WebApplication.Infrastructure.Data.Models.Event;

namespace Formula1WebApplication.Tests
{
    [TestFixture]
    public class EventServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private EventService _eventService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _eventService = new EventService(_mockRepository.Object);

            var events = new List<Event>
            {
                new Event { Id = 3, Name = "Event C", Description = "Third Event", ImageUrl = "ImageUrl3", Location = "Location3", Date = DateTime.Now },
                new Event { Id = 2, Name = "Event B", Description = "Second Event", ImageUrl = "ImageUrl2", Location = "Location2", Date = DateTime.Now },
                new Event { Id = 1, Name = "Event A", Description = "First Event", ImageUrl = "ImageUrl1", Location = "Location1", Date = DateTime.Now }
            }.AsQueryable();

            var mockSet = events.BuildMockDbSet();

            _mockRepository.Setup(repo => repo.All<Event>()).Returns(mockSet.Object);
            _mockRepository.Setup(r => r.AllReadOnly<Event>()).Returns(mockSet.Object);
            _mockRepository.Setup(r => r.AddAsync(It.IsAny<Event>())).Returns(Task.CompletedTask).Verifiable();
            _mockRepository.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1).Verifiable();

            var eventUsers = new List<EventUser>
            {
                new EventUser {EventId = 1, UserId = "user1", Event = events.First(e => e.Id == 1)},
                new EventUser {EventId = 2, UserId = "user2", Event = events.First(e => e.Id == 2)}
            }.AsQueryable();


            var mockEventUserDbSet = eventUsers.BuildMockDbSet();
            _mockRepository.Setup(r => r.All<EventUser>()).Returns(mockEventUserDbSet.Object);
        }

        [Test]
        public async Task GetAllEventsAsync_WithParameters_ReturnsPaginatedAndSortedEvents()
        {
            int pageIndex = 1;
            int pageSize = 2;
            string searchString = "Event";
            string sortOrder = "name_desc";

            var result = await _eventService.GetAllEventsAsync(pageIndex, pageSize, searchString, sortOrder);

            Assert.That(result.Count, Is.EqualTo(2), "Should return the correct number of events on the first page.");
            Assert.That(result.TotalCount, Is.EqualTo(3), "Should return the correct total number of events.");
            Assert.That(result.Select(e => e.Name), Is.Ordered.Descending, "Events should be ordered by name descending.");
        }

        [Test]
        public async Task GetDetailsAsync_WithExistingId_ReturnsCorrectDetails()
        {
            var events = new List<Event>
            {
                new Event { Id = 1, Name = "Event1", Description = "First Event", ImageUrl = "URL1", Location = "Location1", Date = new DateTime(2024, 1, 1) },
                new Event { Id = 2, Name = "Event2", Description = "Second Event", ImageUrl = "URL2", Location = "Location2", Date = new DateTime(2024, 2, 1) }
            }.AsQueryable();

            var mockSet = events.BuildMockDbSet();
            _mockRepository.Setup(r => r.AllReadOnly<Event>()).Returns(mockSet.Object);

            int searchId = 1;

            var result = await _eventService.GetDetailsAsync(searchId);

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(searchId));
            Assert.That(result.Name, Is.EqualTo("Event1"));
            Assert.That(result.Description, Is.EqualTo("First Event"));
            Assert.That(result.ImageUrl, Is.EqualTo("URL1"));
            Assert.That(result.Location, Is.EqualTo("Location1"));
            Assert.That(result.Date, Is.EqualTo(new DateTime(2024, 1, 1)));
        }

        [Test]
        public async Task AddAsync_CreatesNewEvent_AndSavesChanges()
        {
            var organizerId = 10; 
            var newEventModel = new EventServiceModel
            {
                Name = "New Event",
                Description = "New Event Description",
                ImageUrl = "http://newevent.image.url",
                Location = "New Event Location",
                Date = new DateTime(2024, 4, 24) 
            };

            await _eventService.AddAsync(newEventModel, organizerId);

            _mockRepository.Verify(repo => repo.AddAsync(It.Is<Event>(e =>
                e.Name == newEventModel.Name &&
                e.Description == newEventModel.Description &&
                e.ImageUrl == newEventModel.ImageUrl &&
                e.Location == newEventModel.Location &&
                e.Date == newEventModel.Date &&
                e.OrganizerId == organizerId)), Times.Once);

            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task EditAsync_ExistingEventId_UpdatesEvent()
        {
            var eventId = 1;
            var existingEvent = new Event
            {
                Id = eventId,
                Name = "Old Name",
                Description = "Old Description",
                ImageUrl = "OldImageUrl",
                Location = "Old Location",
                Date = DateTime.Now
            };

            var updatedEvent = new EventServiceModel
            {
                Name = "Updated Event",
                Description = "Updated Description",
                ImageUrl = "http://updatedevent.image.url",
                Location = "Updated Location",
                Date = new DateTime(2024, 5, 25)
            };

            _mockRepository.Setup(repo => repo.GetByIdAsync<Event>(It.IsAny<int>()))
                           .ReturnsAsync(existingEvent);

            await _eventService.EditAsync(eventId, updatedEvent);

            Assert.That(existingEvent.Name, Is.EqualTo(updatedEvent.Name), "Event name should be updated.");
            Assert.That(existingEvent.Description, Is.EqualTo(updatedEvent.Description), "Event description should be updated.");
            Assert.That(existingEvent.ImageUrl, Is.EqualTo(updatedEvent.ImageUrl), "Event ImageUrl should be updated.");
            Assert.That(existingEvent.Location, Is.EqualTo(updatedEvent.Location), "Event location should be updated.");
            Assert.That(existingEvent.Date, Is.EqualTo(updatedEvent.Date), "Event date should be updated.");
        }

        [Test]
        public async Task HasOrganizerWithIdAsync_WithCorrectOrganizerId_ReturnsTrue()
        {
            var events = new List<Event>
            {
                new Event { Id = 1, Organizer = new Organizer { UserId = "user1" } },
            }.AsQueryable();

            var mockSet = events.BuildMockDbSet();
            _mockRepository.Setup(r => r.AllReadOnly<Event>()).Returns(mockSet.Object);

            var result = await _eventService.HasOrganizerWithIdAsync(1, "user1");

            Assert.IsTrue(result);
        }

        [Test]
        public async Task HasOrganizerWithIdAsync_WithCorrectOrganizerId_ReturnsFalse()
        {
            var events = new List<Event>
            {
                new Event { Id = 1, Organizer = new Organizer { UserId = "user1" } },
            }.AsQueryable();

            var mockSet = events.BuildMockDbSet();
            _mockRepository.Setup(r => r.AllReadOnly<Event>()).Returns(mockSet.Object);

            var result = await _eventService.HasOrganizerWithIdAsync(1, "user2");

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetEventServiceModelByIdAsync_ExistingId_ReturnsEventModel()
        {
            int searchId = 1;
            var expectedEvent = new Event
            {
                Id = searchId,
                Name = "Event A",
                Description = "First Event",
                ImageUrl = "ImageUrl1",
                Location = "Location1",
                Date = DateTime.Now
            };

            var result = await _eventService.GetEventServiceModelByIdAsync(searchId);

            Assert.IsNotNull(result, "Result should not be null for an existing event ID.");
            Assert.That(result.Id, Is.EqualTo(expectedEvent.Id), "Event ID should match the search ID.");
            Assert.That(result.Name, Is.EqualTo(expectedEvent.Name), "Event Name should match the expected value.");
            Assert.That(result.Description, Is.EqualTo(expectedEvent.Description),
                "Event Description should match the expected value.");
            Assert.That(result.ImageUrl, Is.EqualTo(expectedEvent.ImageUrl),
                "Event ImageUrl should match the expected value.");
            Assert.That(result.Location, Is.EqualTo(expectedEvent.Location),
                "Event Location should match the expected value.");
        }

        [Test]
        public async Task DeleteAsync_ExistingEventId_DeletesEventAndSavesChanges()
        {
            int eventIdToDelete = 1;
            var @event = new Event { Id = eventIdToDelete };

            _mockRepository.Setup(repo => repo.GetByIdAsync<Event>(It.IsAny<int>()))
                .ReturnsAsync(@event);

            _mockRepository.Setup(repo => repo.DeleteAsync<Event>(It.IsAny<int>()))
                .Callback((object id) =>
                {
                    Assert.That(id, Is.EqualTo(eventIdToDelete), "Should delete the event with the correct ID.");
                });

            _mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(1);

            await _eventService.DeleteAsync(eventIdToDelete);

            _mockRepository.Verify(repo => repo.DeleteAsync<Event>(It.IsAny<int>()), Times.Once, "Method DeleteAsync was not called exactly once.");
            _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once, "Method SaveChangesAsync was not called exactly once.");
        }

        [Test]
        public async Task JoinEventAsync_UserNotJoined_AddsUserToEventAndReturnsTrue()
        {
            int eventId = 1;
            string userId = "user1";

            _mockRepository.Setup(repo => repo.All<EventUser>())
                           .Returns(new List<EventUser>().AsQueryable().BuildMockDbSet().Object);

            _mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(1);

            bool result = await _eventService.JoinEventAsync(eventId, userId);

            Assert.IsTrue(result, "Method should return true when a user is added to an event.");
            _mockRepository.Verify(repo => repo.SaveChangesAsync(),
                Times.Once, "Method SaveChangesAsync should be called once to save the new EventUser.");
        }

        [Test]
        public async Task IsJoinedByUserWithIdAsync_UserJoined_ReturnsTrue()
        {
            int eventId = 1;
            string userId = "user1"; 

            bool isJoined = await _eventService.IsJoinedByIUserWithIdAsync(eventId, userId);

            Assert.IsTrue(isJoined, "The method should return true if the user is joined to the event.");
        }

        [Test]
        public async Task IsJoinedByUserWithIdAsync_UserNotJoined_ReturnsFalse()
        {
            int eventId = 1;
            string userId = "user3";

            bool isJoined = await _eventService.IsJoinedByIUserWithIdAsync(eventId, userId);

            Assert.IsFalse(isJoined, "The method should return false if the user is not joined to the event.");
        }

        [Test]
        public async Task GetMyEventsAsync_UserHasEvents_ReturnsUserEvents()
        {
            string userId = "user1";

            var userEvents = await _eventService.GetMyEventsAsync(userId);

            Assert.IsNotEmpty(userEvents, "Should return a non-empty collection of events for the user.");
        }

        [Test]
        public async Task GetMyEventsAsync_UserHasNoEvents_ReturnsEmpty()
        {
            string userId = "user-x"; 

            var userEvents = await _eventService.GetMyEventsAsync(userId);

            Assert.IsEmpty(userEvents, "Should return an empty collection for a user with no events.");
        }

        [Test]
        public async Task LeaveEventAsync_WhenUserIsJoined_EventUserIsRemovedAndReturnsTrue()
        {
            int eventId = 1;
            string userId = "user1"; 

            EventUser removedEventUser = null; 
            _mockRepository.Setup(r => r.Remove(It.IsAny<EventUser>()))
                           .Callback<EventUser>(eu => removedEventUser = eu);

            bool result = await _eventService.LeaveEventAsync(eventId, userId);

            Assert.IsTrue(result, "Should return true if the event user is successfully removed.");
            Assert.IsNotNull(removedEventUser, "No event user was removed.");
            Assert.That(removedEventUser.EventId, Is.EqualTo(eventId), "The removed event user should have the correct event ID.");
            Assert.That(removedEventUser.UserId, Is.EqualTo(userId), "The removed event user should have the correct user ID.");

            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}

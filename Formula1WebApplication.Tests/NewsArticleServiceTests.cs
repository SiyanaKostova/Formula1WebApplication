using Formula1WebApplication.Core.Models.NewsArticle;
using Formula1WebApplication.Core.Services;
using Formula1WebApplication.Infrastructure.Common;
using Formula1WebApplication.Infrastructure.Data.Models;
using Formula1WebApplication.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;

namespace Formula1WebApplication.Tests
{
    [TestFixture]
    public class NewsArticleServiceTests
    {
        private Mock<IRepository> mockRepository;
        private NewsArticleService newsArticleService;
        private Mock<DbSet<NewsArticle>> mockSet;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IRepository>();
            newsArticleService = new NewsArticleService(mockRepository.Object);

            var data = new List<NewsArticle>
            {
            new NewsArticle { Id = 1, Title = "First Article", Description = "Description 1", ImageUrl = "URL1" },
            new NewsArticle { Id = 2, Title = "Second Article", Description = "Description 2", ImageUrl = "URL2" },
            new NewsArticle { Id = 3, Title = "Third Article", Description = "Description 3", ImageUrl = "URL3" },
            new NewsArticle { Id = 4, Title = "Fourth Article", Description = "Description 4", ImageUrl = "URL4" }
            }.AsQueryable();

            mockSet = data.BuildMockDbSet();
            mockRepository.Setup(r => r.AllReadOnly<NewsArticle>()).Returns(mockSet.Object);
        }

        [Test]
        public async Task LastThreeNewsArticlesAsync_ReturnsExactlyThreeArticles_InCorrectOrder()
        {
            var result = await newsArticleService.LastThreeNewsArticlesAsync();

            Assert.That(result.Count(), Is.EqualTo(3), "Should return exactly three news articles.");
            Assert.That(result.First().Id, Is.EqualTo(4), "First article should have the highest ID.");
            Assert.That(result.ElementAt(1).Id, Is.EqualTo(3), "Second article should have the second highest ID.");
            Assert.That(result.ElementAt(2).Id, Is.EqualTo(2), "Third article should have the third highest ID.");
        }

        [Test]
        public async Task GetNewsArticleServiceModelByIdAsync_ExistingId_ReturnsCorrectArticle()
        {
            int searchId = 1;

            var result = await newsArticleService.GetNewsArticleServiceModelByIdAsync(searchId);

            Assert.IsNotNull(result, "Should return a NewsArticleServiceModel object.");
            Assert.That(result.Id, Is.EqualTo(searchId), "The ID of the retrieved article should match the requested ID.");
            Assert.That(result.Title, Is.EqualTo("First Article"), "The title of the retrieved article should match.");
        }

        [Test]
        public async Task GetNewsArticleServiceModelByIdAsync_NonExistingId_ReturnsNull()
        {
            int searchId = 99;

            var result = await newsArticleService.GetNewsArticleServiceModelByIdAsync(searchId);

            Assert.IsNull(result, "Should return null for a non-existing article ID.");
        }

        [Test]
        public async Task AddAsync_ValidNewsArticle_AddsArticleAndSavesChanges()
        {
            var newsArticleModel = new NewsArticleServiceModel
            {
                Title = "New Article",
                Description = "New description",
                ImageUrl = "new_image_url"
            };

            int organizerId = 1;

            mockRepository
                .Setup(repo => repo.AddAsync(It.IsAny<NewsArticle>()))
                .Callback<NewsArticle>(article =>
                {
                    Assert.That(article.Title, Is.EqualTo(newsArticleModel.Title), "Titles should match");
                    Assert.That(article.Description, Is.EqualTo(newsArticleModel.Description), "Descriptions should match");
                    Assert.That(article.ImageUrl, Is.EqualTo(newsArticleModel.ImageUrl), "Image URLs should match");
                    Assert.That(article.OrganizerId, Is.EqualTo(organizerId), "Organizer IDs should match");
                })
                .Returns(Task.CompletedTask);

            mockRepository
                .Setup(repo => repo.SaveChangesAsync())
                .Returns(Task.FromResult(0));

            await newsArticleService.AddAsync(newsArticleModel, organizerId);

            mockRepository.Verify(repo => repo.AddAsync(It.IsAny<NewsArticle>()), Times.Once, "Expected AddAsync to be called once");
            mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once, "Expected SaveChangesAsync to be called once");
        }

        [Test]
        public async Task EditAsync_ExistingArticle_UpdatesPropertiesAndSavesChanges()
        {
            int existingId = 1;
            var existingArticle = new NewsArticle { Id = existingId, Title = "Old Title", Description = "Old Description", ImageUrl = "OldURL" };
            var newModel = new NewsArticleServiceModel { Title = "New Title", Description = "New Description", ImageUrl = "NewURL" };

            mockRepository.Setup(repo => repo.GetByIdAsync<NewsArticle>(existingId)).ReturnsAsync(existingArticle);
            mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(1);

            await newsArticleService.EditAsync(existingId, newModel);

            mockRepository.Verify(repo => repo.GetByIdAsync<NewsArticle>(existingId), Times.Once);
            Assert.That(existingArticle.Title, Is.EqualTo(newModel.Title));
            Assert.That(existingArticle.Description, Is.EqualTo(newModel.Description));
            Assert.That(existingArticle.ImageUrl, Is.EqualTo(newModel.ImageUrl));
            mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task GetArticlesAsync_WithSortingAndPaging_ReturnsPaginatedSortedResults()
        {
            var articles = new List<NewsArticle>
            {
                new NewsArticle { Id = 1, Title = "Alpha", Description = "First Article", ImageUrl = "URL1" },
                new NewsArticle { Id = 2, Title = "Bravo", Description = "Second Article with Bravo", ImageUrl = "URL2" },
                new NewsArticle { Id = 3, Title = "Charlie", Description = "Third Article", ImageUrl = "URL3" }
            }.AsQueryable();

            var mockSet = articles.BuildMockDbSet();
            mockRepository.Setup(r => r.All<NewsArticle>()).Returns(mockSet.Object);

            string sortOrder = "title";
            string searchString = "Bravo";
            int pageIndex = 1;
            int pageSize = 1;

            var result = await newsArticleService.GetArticlesAsync(sortOrder, searchString, pageIndex, pageSize);

            Assert.That(result, Is.TypeOf<PaginatedList<NewsArticleServiceModel>>());
            Assert.That(result.TotalCount, Is.EqualTo(1), "Should have filtered to one result.");
            Assert.That(result.PageIndex, Is.EqualTo(pageIndex), "Should have the correct page index.");
            Assert.That(result.TotalPages, Is.EqualTo(1), "Should calculate total pages correctly.");
            Assert.That(result.First().Title, Is.EqualTo("Bravo"), "Should be ordered by title and filtered by search string.");
        }

        [Test]
        public async Task GetDetailsAsync_WithExistingId_ReturnsCorrectDetails()
        {
            var articles = new List<NewsArticle>
            {
                new NewsArticle { Id = 1, Title = "Alpha", Description = "First Article", ImageUrl = "URL1" },
                new NewsArticle { Id = 2, Title = "Bravo", Description = "Second Article", ImageUrl = "URL2" }
            }.AsQueryable();

            var mockSet = articles.BuildMockDbSet();
            mockRepository.Setup(r => r.AllReadOnly<NewsArticle>()).Returns(mockSet.Object);

            int searchId = 1;

            var result = await newsArticleService.GetDetailsAsync(searchId);

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(searchId));
            Assert.That(result.Title, Is.EqualTo("Alpha"));
            Assert.That(result.Description, Is.EqualTo("First Article"));
            Assert.That(result.ImageUrl, Is.EqualTo("URL1"));
        }

        [Test]
        public async Task GetDetailsAsync_WithNonExistingId_ReturnsNull()
        {
            var articles = new List<NewsArticle>
            {
                new NewsArticle { Id = 1, Title = "Alpha", Description = "First Article", ImageUrl = "URL1" },
                new NewsArticle { Id = 2, Title = "Bravo", Description = "Second Article", ImageUrl = "URL2" }
            }.AsQueryable();

            var mockSet = articles.BuildMockDbSet();
            mockRepository.Setup(r => r.AllReadOnly<NewsArticle>()).Returns(mockSet.Object);

            int searchId = 99; 

            var result = await newsArticleService.GetDetailsAsync(searchId);

            Assert.IsNull(result);
        }

        [Test]
        public async Task HasOrganizerWithIdAsync_WithCorrectOrganizerId_ReturnsTrue()
        {
            var articles = new List<NewsArticle>
            {
                new NewsArticle { Id = 1, Title = "Article 1", Organizer = new Organizer { UserId = "user1" } },
            }.AsQueryable();

            var mockSet = articles.BuildMockDbSet();
            mockRepository.Setup(r => r.AllReadOnly<NewsArticle>()).Returns(mockSet.Object);

            var result = await newsArticleService.HasOrganizerWithIdAsync(1, "user1");

            Assert.IsTrue(result);
        }

        [Test]
        public async Task HasOrganizerWithIdAsync_WithIncorrectOrganizerId_ReturnsFalse()
        {
            var articles = new List<NewsArticle>
            {
                new NewsArticle { Id = 1, Title = "Article 1", Organizer = new Organizer { UserId = "user1" } },
            }.AsQueryable();

            var mockSet = articles.BuildMockDbSet();
            mockRepository.Setup(r => r.AllReadOnly<NewsArticle>()).Returns(mockSet.Object);

            var result = await newsArticleService.HasOrganizerWithIdAsync(1, "user2");

            Assert.IsFalse(result);
        }

        [Test]
        public async Task HasOrganizerWithIdAsync_WithNonExistingArticleId_ReturnsFalse()
        {
            var articles = new List<NewsArticle>
            {
                new NewsArticle { Id = 1, Title = "Article 1", Organizer = new Organizer { UserId = "user1" } },
            }.AsQueryable();

            var mockSet = articles.BuildMockDbSet();
            mockRepository.Setup(r => r.AllReadOnly<NewsArticle>()).Returns(mockSet.Object);

            var result = await newsArticleService.HasOrganizerWithIdAsync(99, "user1");

            Assert.IsFalse(result);
        }

        [Test]
        public async Task DeleteAsync_ExistingArticleId_DeletesArticleAndSavesChanges()
        {
            int newsArticleIdToDelete = 1;
            var newsArticle = new NewsArticle { Id = newsArticleIdToDelete };

            mockRepository.Setup(repo => repo.GetByIdAsync<NewsArticle>(It.IsAny<int>()))
                          .ReturnsAsync(newsArticle);

            mockRepository.Setup(repo => repo.DeleteAsync<NewsArticle>(It.IsAny<int>()))
                          .Callback((object id) =>
                          {
                              Assert.That(id, Is.EqualTo(newsArticleIdToDelete), "Should delete the article with the correct ID.");
                          });

            mockRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(1); 

            await newsArticleService.DeleteAsync(newsArticleIdToDelete);

            mockRepository.Verify(repo => repo.DeleteAsync<NewsArticle>(It.IsAny<int>()), Times.Once, "Method DeleteAsync was not called exactly once.");
            mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once, "Method SaveChangesAsync was not called exactly once.");
        }
    }
}

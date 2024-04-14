using Formula1WebApplication.Core.Contracts.InterfaceModels;
using Formula1WebApplication.Core.Extensions;
using Formula1WebApplication.Core.Models.Event;
using Formula1WebApplication.Core.Models.NewsArticle;
using Formula1WebApplication.Core.Models.Race;

namespace Formula1WebApplication.Tests
{
    [TestFixture]
    public class ModelExtensionsTests
    {
        private INewsArticleModel newsArticle;
        private IEventModel eventModel;
        private IRaceModel raceModel;

        [SetUp]
        public void Setup()
        {
            newsArticle = new NewsArticleServiceModel
            {
                Title = "Breaking News: New Champion",
                Description = "A new champion has been crowned today in a stunning victory."
            };

            eventModel = new EventServiceModel
            {
                Name = "Grand Event 2024",
                Description = "The event of the year featuring top performances."
            };

            raceModel = new RaceServiceModel
            {
                Name = "Grand Prix Victory",
                CircuitInfo = "The circuit saw a historic race with a photo finish."
            };
        }

        [Test]
        public void GetNewsArticleDetails_ReturnsFormattedString()
        {
            var expected = "Breaking-News-New-ChampionA-new-champion";

            var result = newsArticle.GetNewsArticleDetails();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetEventDetails_ReturnsFormattedString()
        {
            var expected = "Grand-Event-2024The-event-of";

            var result = eventModel.GetEventDetails();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetRaceDetails_ReturnsFormattedString()
        {
            var expected = "Grand-Prix-VictoryThe-circuit-saw";

            var result = raceModel.GetRaceDetails();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

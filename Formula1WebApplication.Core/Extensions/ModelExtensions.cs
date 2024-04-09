using Formula1WebApplication.Core.Contracts.InterfaceModels;
using Formula1WebApplication.Infrastructure.Data.Models;
using System.Text.RegularExpressions;

namespace Formula1WebApplication.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetNewsArticleDetails(this INewsArticleModel newsArticle)
        {
            string info = newsArticle.Title.Replace(" ", "-") 
                + GetDescription(newsArticle.Description);

            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

        public static string GetEventDetails(this IEventModel eventModel)
        {
            string info = eventModel.Name.Replace(" ", "-")
                + GetDescription(eventModel.Description);

            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

        public static string GetRaceDetails(this IRaceModel race)
        {
            string info = race.Name.Replace(" ", "-")
                + GetDescription(race.CircuitInfo);

            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

        private static string GetDescription(string description)
        {
            description = string.Join("-", description.Split(" ").Take(3));

            return description;
        }
    }
}

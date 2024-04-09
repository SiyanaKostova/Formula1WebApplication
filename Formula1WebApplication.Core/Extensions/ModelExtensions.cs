using Formula1WebApplication.Core.Contracts.InterfaceModels;
using System.Text.RegularExpressions;

namespace Formula1WebApplication.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetNewsArticleDetails(this INewsArticleModel newsArticle)
        {
            string info = newsArticle.Title.Replace(" ", "-") + GetDescription(newsArticle.Description);

            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

        private static string GetDescription(string  description)
        {
            description = string.Join("-", description.Split(" ").Take(4));

            return description;
        }
    }
}

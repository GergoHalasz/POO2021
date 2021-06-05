using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleList.Enums;
using ArticleList.Models;
using ArticleList.Services;

namespace ArticleList.Controllers
{
    class ArticleController
    {
        public ArticleApi ArticleService { get; }
        public NewsSource NewsSource;
        private string NewsSourceRoute { get; set; }
        Dictionary<NewsSource, string> NewsSourceMap = new Dictionary<NewsSource, string>
        {
            {NewsSource.BBC_NEWS, "everything/bbc-news.json" },
            {NewsSource.CNN, "everything/cnn.json" },
            {NewsSource.Fox_News, "everything/fox-news.json" },
            {NewsSource.Google_News, "everything/google-news.json" },
        };

        public ArticleController(ArticleApi articleService, NewsSource newsSource)
        {
            ArticleService = articleService;
            SetNewsSource(newsSource);
        }

        public void SetNewsSource(NewsSource newsSource)
        {
            NewsSource = newsSource;
            NewsSourceRoute = NewsSourceMap[NewsSource];
        }

        #region Filter

        public async Task<IEnumerable<Article>> GetArticles() => (await ArticleService.GetArticles(NewsSourceRoute)).Articles;

        public async Task<IEnumerable<Article>> GetArticlesByAuthor(string author) =>
            (await GetArticles())
                .Where(article => article.Author != null && article.Author
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Any(Author => Author.Trim() == author));

        public async Task<IEnumerable<Article>> GetArticlesByInterval(DateTime startDate, DateTime endDate) =>
            (await GetArticles()).Where(article => article.PublishedAt >= startDate && article.PublishedAt <= endDate);

        public async Task<IEnumerable<Article>> GetArticlesPublishedInWeekend(DateTime startDate, DateTime endDate) =>
            (await GetArticles()).Where(article =>
                article.PublishedAt.DayOfWeek == DayOfWeek.Saturday ||
                article.PublishedAt.DayOfWeek == DayOfWeek.Sunday);

        #endregion

        #region Sort

        public async Task<IEnumerable<Article>> GetSortedByDate() =>
            (await GetArticles()).OrderBy(article => article.PublishedAt);

        public async Task<IEnumerable<string>> GetSortedByPublishCount()
        {
            Dictionary<string, int> authorMap = new Dictionary<string, int>();

            var articles = await GetArticles();

            foreach (var article in articles)
            {
                if (article.Author == null)
                    continue;

                IEnumerable<string> authors = article.Author.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(author => author.Trim());

                foreach (var author in authors)
                    if (authorMap.ContainsKey(author))
                        authorMap[author]++;
                    else
                        authorMap.Add(author, 1);
            }

            return authorMap.Keys.OrderByDescending(author => authorMap[author]).ToList();
        }

        #endregion

        #region Aggregation

        public async Task<int> GetArticleCountBy(string author) => (await GetArticlesByAuthor(author)).Count();

        public async Task<int> GetArticleCountByInterval(DateTime startDate, DateTime endDate) =>
            (await GetArticlesByInterval(startDate, endDate)).Count();

        #endregion
    }
}

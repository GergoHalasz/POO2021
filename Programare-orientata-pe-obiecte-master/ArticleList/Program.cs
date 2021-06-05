using System;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using ArticleList.Controllers;
using ArticleList.Models;
using ArticleList.Services;
using ArticleList.Enums;

namespace ArticleList
{
    class ArticleMain
    {
        static async Task Main(string[] args)
        {
            ArticleController articleController = new ArticleController(new ArticleApi(), NewsSource.Fox_News);

            var articles = await articleController.GetArticles();

            Console.WriteLine(string.Join('\n', articles.Select(article => article.Description)));

        }
    }
}

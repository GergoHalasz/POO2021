using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ArticleList.Models;

namespace ArticleList.Services
{
    // https://documenter.getpostman.com/view/3479169/Szf7zncp?version=latest
    public class ArticleApi
    {
        public HttpClient ApiClient { get; set; }

        public ArticleApi()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://saurav.tech/NewsAPI/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ArticleModel> GetArticles(string newsSource)
        {
            using (HttpResponseMessage response = await ApiClient.GetAsync(newsSource))
            {
                if (response.IsSuccessStatusCode)
                {
                    ArticleModel article = await response.Content.ReadAsAsync<ArticleModel>();
                    return article;
                }

                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}

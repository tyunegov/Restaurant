using Microsoft.AspNetCore.Http;
using Restaurant.Models.News;
using System.Collections.Generic;

namespace Restaurant.ModelView
{
    public interface IRepositoryNews
    {
        public IEnumerable<NewsModel> News { get; set; }
        public IFormFile Image { get; set; }

        NewsModel Edit(int id);
        void Edit(NewsModel model);
        NewsModel Get(int value);
        void Create(NewsModel model);
    }
}

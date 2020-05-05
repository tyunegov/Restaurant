using Microsoft.AspNetCore.Http;
using Restaurant.Models.News;
using Restaurant.ModelView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.TestData
{
    public class TestNews : IRepositoryNews
    {
        IEnumerable<NewsModel> news = new List<NewsModel>()
        {
            new NewsModel(){Id=1, 
                Description="SkyLounge соскучился по любимым гостям! "+
                            "С сегодняшнего дня работаем в обычном вкусном режиме "+
                            "Забегайте на завтрак, обед и ужин "+
                            "Рекомендуем бронировать столики на веранде заранее - желающих очень много",
                Image=File.ReadAllBytes(@"C:\Users\Тюнеговы\Desktop\Restaurant\Restaurant\TestData\image\image1.jpg")
            },
        };

        public IFormFile Image { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<NewsModel> News { get { return news; } set=> throw new NotImplementedException(); }

        public void Create(NewsModel model)
        {
            throw new NotImplementedException();
        }

        public NewsModel Edit(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(NewsModel model)
        {
            throw new NotImplementedException();
        }

        public NewsModel Get(int value)
        {
            return new NewsModel()
            {
                Id = 1,
                Description = "SkyLounge соскучился по любимым гостям! " +
                            "С сегодняшнего дня работаем в обычном вкусном режиме " +
                            "Забегайте на завтрак, обед и ужин " +
                            "Рекомендуем бронировать столики на веранде заранее - желающих очень много",
                Image = File.ReadAllBytes(@"C:\Users\Тюнеговы\Desktop\Restaurant\Restaurant\TestData\image\image1.jpg")
            };
        }
    }
}

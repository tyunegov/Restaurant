using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models.News
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}

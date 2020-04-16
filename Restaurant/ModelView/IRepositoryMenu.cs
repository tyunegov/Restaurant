using Restaurant.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.ModelView
{
    public interface IRepositoryMenu
    {
        public IEnumerable<CategoryMenu> Categories { get; set; }
        public IEnumerable<TypeMenu> Types { get; set; }
        public IEnumerable<Menu> Menu { get; set; }

        IEnumerable<CategoryMenu> GetCategoriesFortypeId(int typeId);
        IEnumerable<Menu> GetMenuForCategoryId(int? categoryId);
    }
}

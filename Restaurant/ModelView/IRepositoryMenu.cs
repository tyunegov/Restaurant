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
        IEnumerable<Menu> GetMenuForCategoryId(int categoryId);
        CategoryMenu GetCategory(int id);
        void EditType(int id, TypeMenu type);
        void EditCategory(int id, CategoryMenu category);
        Menu GetMenu(int id);
        TypeMenu GetTypeMenu(int id);
        void EditMenu(int id, Menu menu);
        void CreateType(TypeMenu type);
        void CreateMenu(Menu menu);
        void CreateCategory(CategoryMenu category);
    }
}

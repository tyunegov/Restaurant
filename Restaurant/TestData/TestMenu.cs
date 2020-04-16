using Restaurant.Models.Menu;
using Restaurant.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.TestData
{
    public class TestMenu : IRepositoryMenu
    {
        IEnumerable<TypeMenu> types = new List<TypeMenu>()
        {
            new TypeMenu(){ Id=1, Name="Type1"},
            new TypeMenu(){ Id=2, Name="Type2"},
        };
        IEnumerable<CategoryMenu> categories = new List<CategoryMenu>()
        {
            new CategoryMenu(){ Id=1, Name="Category1", TypeId=1},
            new CategoryMenu(){ Id=2, Name="Category1", TypeId=1},
            new CategoryMenu(){ Id=3, Name="Category1", TypeId=1},
            new CategoryMenu(){ Id=4, Name="Category1", TypeId=2},
            new CategoryMenu(){ Id=5, Name="Category1", TypeId=2},
        };
        IEnumerable<Menu> menu = new List<Menu>()
        {
            new Menu(){ Id=1, Name="Menu1", Description="Description", CategoryId=1, Price=100, Count=350},
            new Menu(){ Id=2, Name="Menu2", Description="Description", CategoryId=2, Price=100, Count=350},
            new Menu(){ Id=3, Name="Menu3", Description="Description", CategoryId=3, Price=100, Count=350},
            new Menu(){ Id=4, Name="Menu4", Description="Description", CategoryId=4, Price=100, Count=350},
            new Menu(){ Id=5, Name="Menu5", Description="Description", CategoryId=5, Price=100, Count=350},
            new Menu(){ Id=6, Name="Menu1", Description="Description", CategoryId=1, Price=100, Count=350},
            new Menu(){ Id=7, Name="Menu1", Description="Description", CategoryId=1, Price=100, Count=350},
            new Menu(){ Id=8, Name="Menu1", Description="Description", CategoryId=1, Price=100, Count=350},
            new Menu(){ Id=9, Name="Menu1", Description="Description", CategoryId=1, Price=100, Count=350},
            new Menu(){ Id=10, Name="Menu1", Description="Description", CategoryId=1, Price=100, Count=350},

        };
        public IEnumerable<CategoryMenu> Categories {
            get {
                 foreach(var v in categories)
                 {
                    v.Type = types.Where(x=>x.Id==v.TypeId).FirstOrDefault();
                 }
                return categories;
            }
            set { throw new NotImplementedException(); } }
        public IEnumerable<TypeMenu> Types { get { return types; } set { throw new NotImplementedException(); } }
        public IEnumerable<Menu> Menu { get { return menu; } set { throw new NotImplementedException(); } }

        public IEnumerable<CategoryMenu> GetCategoriesFortypeId(int typeId)
        {
            foreach(var v in categories)
            {
                v.Menu = menu.Where(x=>x.CategoryId==v.Id);
            }
            return categories;
        }

        public IEnumerable<Menu> GetMenuForCategoryId(int? categoryId)
        {
            throw new NotImplementedException();
        }
    }
}

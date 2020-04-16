using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models.Menu;
using Restaurant.Models.Book;
using Restaurant.Models.User;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        Database.EnsureCreated();
    }

    public DbSet<Menu> MenuDB { get; set; }
    public DbSet<CategoryMenu> CategoriesDB { get; set; }
    public DbSet<TypeMenu> TypesDB { get; set; }

    public DbSet<Booking> BookingDB { get; set; }

    public DbSet<User> User { get; set; }
    }

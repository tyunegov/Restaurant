using Restaurant.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.ModelView
{
    public interface IRepositoryUser
    {
        IEnumerable<User> Users { get; set; }

        User Get(int? id);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
        User Get(LoginModel model);
        User Get(string name);
    }
}

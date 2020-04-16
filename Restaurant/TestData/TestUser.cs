using Restaurant.Models.User;
using Restaurant.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.TestData
{
    public class TestUser : IRepositoryUser
    {
        public IEnumerable<Role> Roles
        {
            get
            {
                return new List<Role>()
                {
                    new Role(){Id=1, Name="admin"},
                    new Role(){Id=2, Name="moderator"},
                };
            }
        }
        public IEnumerable<User> Users
        {
            get
            {
                return new List<User>()
                {
                    new User(){ Id=1, Name="admin", Password="123", RoleId=1},
                    new User(){Id=2, Name="moderator", Password="123", RoleId=2 },
                };
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int? id)
        {
            return Users.Where(x=>x.Id==id).FirstOrDefault();
        }

        public User Get(LoginModel model)
        {
            User user = Users
                    .Where(x=>x.Name==model.Name)
                    .Where(x=>x.Password==model.Password)
                    .FirstOrDefault();
            user.Role = Roles.Where(x => x.Id == user.RoleId).FirstOrDefault();
            return user;
        }

        public User Get(string name)
        {
            return Users.Where(x => x.Name == name).FirstOrDefault();   
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}

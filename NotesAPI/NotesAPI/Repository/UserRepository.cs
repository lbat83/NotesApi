using NotesAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Repository
{
    public class UserRepository : IRepository<User>
    {
        static List<User> UserList = new List<User>();

        public void Add(User item)
        {
            UserList.Add(item);
        }

        public IEnumerable<User> GetAll()
        {
            return UserList.ToList();
        }

        public User GetById(int id)
        {
            return UserList.Where(u => u.Id.Equals(id)).SingleOrDefault();
        }

        public void Remove(int Id)
        {
            var itemToRemove = UserList.SingleOrDefault(r => r.Id == Id);
            if (itemToRemove != null)
                UserList.Remove(itemToRemove);
        }

        public void Update(User item)
        {
            var itemToUpdate = UserList.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.Email = item.Email;
                itemToUpdate.CreatedOn = item.CreatedOn = DateTime.Now;
            }
        }
    }
}

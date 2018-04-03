
using NotesAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        static List<Category> CatList = new List<Category>();

        public void Add(Category item)
        {
            CatList.Add(item);
        }

        public IEnumerable<Category> GetAll()
        {
            return CatList.ToList();
        }

        public Category GetById(int id)
        {
            return CatList.Where(c => c.Id.Equals(id)).SingleOrDefault();
        }

        public void Remove(int Id)
        {
            var itemToRemove = CatList.SingleOrDefault(r => r.Id== Id);
            if (itemToRemove != null)
                CatList.Remove(itemToRemove); 
        }

        public void Update(Category item)
        {
            var itemToUpdate = CatList.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
               
            }
        }
    }
}

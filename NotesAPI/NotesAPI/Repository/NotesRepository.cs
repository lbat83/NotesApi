using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesAPI.Models.Entities;

namespace NotesAPI.Repository
{
    public class NotesRepository : IRepository<Notes>
    {
        static List<Notes> NotesList = new List<Notes>();

        public void Add(Notes item)
        {
            NotesList.Add(item);
        }

        public IEnumerable<Notes> GetAll()
        {
            return NotesList;
        }

        public Notes GetById(int id)
        {
            return NotesList.Where(n => n.Id.Equals(id)).SingleOrDefault();
        }

        public void Remove(int Id)
        {
            var itemToRemove = NotesList.SingleOrDefault(r => r.Id == Id);
            if (itemToRemove != null)
                NotesList.Remove(itemToRemove);
        }

        public void Update(Notes item)
        {
            var itemToUpdate = NotesList.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                
                itemToUpdate.Title = item.Title;
                itemToUpdate.Note = item.Note;
                itemToUpdate.CreatedOn = item.CreatedOn = DateTime.Now;
                itemToUpdate.CategoryId = item.CategoryId;
                itemToUpdate.IsDeleted = item.IsDeleted;
                itemToUpdate.UserId = item.UserId;
            }
        }
    }
}

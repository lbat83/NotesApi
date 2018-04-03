using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesAPI.Models.Entities;
using NotesAPI.Repository.Context;

namespace NotesAPI.Repository
{
    public class NotesRepository : IRepository<Notes>
    {
        NotesContext _context;
        public NotesRepository(NotesContext context)
        {
            _context = context;
        }

        public void Add(Notes item)
        {
            _context.Notes.Add(item);
        }

        public IEnumerable<Notes> GetAll()
        {
            return _context.Notes.ToList();
        }

        public Notes GetById(int id)
        {
            return _context.Notes.Where(n => n.Id.Equals(id)).SingleOrDefault();
        }

        public void Remove(int Id)
        {
            var itemToRemove = _context.Notes.SingleOrDefault(r => r.Id == Id);
            if (itemToRemove != null)
                _context.Notes.Remove(itemToRemove);
        }

        public void Update(Notes item)
        {
            var itemToUpdate = _context.Notes.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                
                itemToUpdate.Title = item.Title;
                itemToUpdate.Note = item.Note;
                itemToUpdate.CreatedOn = item.CreatedOn = DateTime.Now;
                itemToUpdate.CategoryId = item.CategoryId;
                itemToUpdate.IsDeleted = item.IsDeleted;
                itemToUpdate.UserId = item.UserId;
                _context.SaveChanges();
            }
        }
    }
}

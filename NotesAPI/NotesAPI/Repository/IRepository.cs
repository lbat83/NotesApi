using NotesAPI;
using NotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Repository
{
    public interface IRepository<T>
    {
        void Add(T item);

        IEnumerable<T> GetAll();

        T GetById(int id);

        void Update(T item);

        void Remove(int item);
    }
}

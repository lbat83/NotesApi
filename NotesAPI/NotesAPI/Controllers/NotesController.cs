using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Models.Entities;
using NotesAPI.Repository;

namespace NotesAPI.Controllers
{

    [Route("api/Notes")]
    public class NotesController : Controller
    {
        public IRepository<Notes> NotesRepo { get; set; }

        public NotesController(IRepository<Notes> _repo)
        {
            NotesRepo = _repo;

        }

        // GET: api/Notes
        [HttpGet]
        public IEnumerable<Notes> GetAll()
        {
            return NotesRepo.GetAll();
        }

        // GET: api/Notes/5
        [HttpGet("{id}", Name = "GetNotes")]
        public IActionResult GetbyId(int id)
        {
            var item = NotesRepo.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        
        // POST: api/Notes
        [HttpPost]
        public IActionResult Post([FromBody] Notes item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            NotesRepo.Add(item);
            return CreatedAtRoute("GetNotes", new { Controller = "Notes", id = item.Id }, item);
        }
        
        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Notes item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var NotesObj = NotesRepo.GetById(id);
            if (NotesObj == null)
            {
                return NotFound();
            }
            NotesRepo.Update(item);
            return new NoContentResult();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            NotesRepo.Remove(id);
        }
    }
}

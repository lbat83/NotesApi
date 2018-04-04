using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes_API.Entities;

namespace Notes_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Notes")]
    public class NotesController : Controller
    {
        private readonly NotesContext _context;

        public NotesController(NotesContext context)
        {
            _context = context;
        }
        // GET: api/Notes
        [HttpGet]
        public IEnumerable<Notes> GetAll()
        {
            return _context.Notes.ToList();
        }

        // GET: api/Notes/5
        [HttpGet("{id}", Name = "GetNotes")]
        public IActionResult GetById(int id)
        {
            var item = _context.Notes.FirstOrDefault(n => n.Id == id);
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
            _context.Notes.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetNotes", new { id = item.Id }, item);
        }
        
        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

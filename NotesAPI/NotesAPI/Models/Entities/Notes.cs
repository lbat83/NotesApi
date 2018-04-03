using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Models.Entities
{
    public class Notes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }


       // public User User { get; set; }
      //  public Category Category { get; set; }

    }
}

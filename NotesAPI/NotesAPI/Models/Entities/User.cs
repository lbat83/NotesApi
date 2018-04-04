using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Models.Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
    }
}

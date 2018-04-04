using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Models.Entities
{
    [Table("Notes", Schema = "Notes")]
    public class Notes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Text), MaxLength(50)]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        public string Note { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public int CategoryId { get; set; }


        public bool IsDeleted { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyNote
{
    public class Archive
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        public DateTime Time { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }

        public virtual User User { get; set; }
    }
}

namespace MyNote
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        public DateTime Time { get; set; }

        [Required]
        [StringLength(50)]
        public string Text { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }

        public virtual User User { get; set; }
    }
}

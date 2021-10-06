using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace csci340lab7.Models
{
    public class Cat
    {
        public int ID { get; set; }
        
        [StringLength(60, MinimumLength = 1)]
        [Required]
        public String Name { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(80)]
        public String Breed { get; set; }

        [Required]
        [StringLength(120)]
        public String FurPattern { get; set; }
    }
}

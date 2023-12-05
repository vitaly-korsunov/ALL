using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
   
        public class Product
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public string? Title { get; set; }
            public string? Description { get; set; }
            [Required]
            public DateTime? CreatedDate { get; set; }
            // [@CustomValidation]
            public int? Addings { get; set; }
            public bool Active { get; set; }
            [Required]
            [Range(1, 10000)]
            public Double? Price { get; set; }
        }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookHomeWorkApi.Models
{
    public class Book:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int NumberofPages { get; set; }
        [Required]
        public string Writers { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public double Price { get; set; }

    }
}

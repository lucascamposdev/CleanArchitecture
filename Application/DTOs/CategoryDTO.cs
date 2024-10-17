using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CategoryDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }
    }
}

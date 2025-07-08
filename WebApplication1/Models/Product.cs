using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class product
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        [ValidateNever]
        public category category { get; set; }
    }
}

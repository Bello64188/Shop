using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Products.DTOs
{
    public record ProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
    }
}

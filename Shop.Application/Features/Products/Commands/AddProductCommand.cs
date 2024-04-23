using MediatR;
using Shop.Application.Features.Products.DTOs;
using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Products.Commands
{
    public class AddProductCommand : IRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
    }


    public class AddProductHandler : IRequestHandler<AddProductCommand>
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public AddProductHandler(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }
        public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await Task.FromResult(_unitOfWorks.Product.Add(new Product
            {
                Name = request.Name,
                CreatedDate = DateTime.Now,
                Description = request.Description,
                Value = request.Value
            }));

        }
    }
}

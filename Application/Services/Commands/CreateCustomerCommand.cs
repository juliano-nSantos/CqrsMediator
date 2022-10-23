using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Commands
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateCustomerCommand, int>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMediator _mediator;

            public CreateProductCommandHandler(ICustomerRepository customerRepository, IMediator mediator)
            {
                _customerRepository = customerRepository;
                _mediator = mediator;
            }

            public async Task<int> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = new Customer();
                customer.Name = command.Name;
                customer.Email = command.Email;

                _customerRepository.Add(customer);
                return customer.Id;
            }
        }
    }
}

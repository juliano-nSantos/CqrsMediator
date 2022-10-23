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
    public class UpdateCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public class UpdateProductCommanHandler : IRequestHandler<UpdateCustomerCommand, int>
        {
            private readonly ICustomerRepository _customer;
            private readonly IMediator _mediator;

            public UpdateProductCommanHandler(ICustomerRepository customer, IMediator mediator)
            {
                _customer = customer;
                _mediator = mediator;
            }

            public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = await _customer.GetById(command.Id);

                if (customer == null) return default;

                customer.Name = command.Name;
                customer.Email = command.Email;

                _customer.Update(customer);

                return customer.Id;
            }
        }
    }
}

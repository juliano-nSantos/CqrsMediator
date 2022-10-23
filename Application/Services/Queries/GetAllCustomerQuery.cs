using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Queries
{
    public class GetAllCustomerQuery : IRequest<IEnumerable<Customer>>
    {
        public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<Customer>>
        {
            private readonly ICustomerRepository _context;
            private readonly IMediator _mediator;

            public GetAllCustomerQueryHandler(ICustomerRepository context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<IEnumerable<Customer>> Handle(GetAllCustomerQuery query, CancellationToken cancellationToken)
            {
                var customerList = await _context.GetAll();

                if (customerList == null) return default;

                return customerList;
            }
        }
    }
}

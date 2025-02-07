using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using Domain;
namespace Application.Activities
{
    public class Create
    {
        public class Command:IRequest {
            public Domain.Activity Activity { get; set; }
        }

        public class Handler :IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);
                await _context.SaveChangesAsync();
                
            }
        }
    }
}
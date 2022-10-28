﻿using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities;

public class Delete
{
    public class Command: IRequest
    {
        public Guid Id { get; set; }
    }
    
    public class Handler: IRequestHandler<Command>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.FindAsync(request.Id);
            if (activity == null)
            {
                throw new Exception("Not Found");
            }

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
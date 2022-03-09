using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Contracrts.Persistence;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Feature.Commands.AddToDoTask
{
    public class AddToDoTaskCommandHandler : IRequestHandler<AddToDoTaskCommand, Guid>
    {
        private readonly IAsyncRepository<ToDoTask> _todoTaskRepository;
        private readonly IMapper _mapper;
        public AddToDoTaskCommandHandler(IAsyncRepository<ToDoTask> todoTaskRepository, IMapper mapper)
        {
            _todoTaskRepository = todoTaskRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddToDoTaskCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var todoTask = _mapper.Map<ToDoTask>(request);

            todoTask = await _todoTaskRepository.AddAsync(todoTask);

            return todoTask.ToDoTaskId;

        }
    }
}

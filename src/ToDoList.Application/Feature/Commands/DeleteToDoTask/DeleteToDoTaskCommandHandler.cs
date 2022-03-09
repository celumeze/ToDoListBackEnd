using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Contracrts.Persistence;
using ToDoList.Application.Exceptions;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Feature.Commands.DeleteToDoTask
{
    public class DeleteToDoTaskCommandHandler : IRequestHandler<DeleteToDoTaskCommand>
    {
        private readonly IAsyncRepository<ToDoTask> _todoTaskRepository;
        private readonly IMapper _mapper;

        public DeleteToDoTaskCommandHandler(IAsyncRepository<ToDoTask> todoTaskRepository, IMapper mapper)
        {
            _mapper = mapper;
            _todoTaskRepository = todoTaskRepository;
        }

        public async Task<Unit> Handle(DeleteToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var taskToDelete = await _todoTaskRepository.GetByIdAsync(request.ToDoTaskId);

            if(taskToDelete == null)
                throw new NotFoundException(nameof(ToDoTask), request.ToDoTaskId);

            await _todoTaskRepository.RemoveAsync(taskToDelete);

            return Unit.Value;
        }
    }
}

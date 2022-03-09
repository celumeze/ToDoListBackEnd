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

namespace ToDoList.Application.Feature.Queries.GetToDoTaskList
{
    public class ToDoTaskListQueryHandler : IRequestHandler<ToDoTaskListQuery, List<ToDoTaskListVm>>
    {
        private readonly IAsyncRepository<ToDoTask> _todoTaskRepository;
        private readonly IMapper _mapper;

        public ToDoTaskListQueryHandler(IAsyncRepository<ToDoTask> todoTaskRepository, IMapper mapper)
        {
            _todoTaskRepository = todoTaskRepository;
            _mapper = mapper;   
        }

        public async Task<List<ToDoTaskListVm>> Handle(ToDoTaskListQuery request, CancellationToken cancellationToken)
        {
            var todoTasks = (await _todoTaskRepository.ListAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<ToDoTaskListVm>>(todoTasks);
        }
    }
}

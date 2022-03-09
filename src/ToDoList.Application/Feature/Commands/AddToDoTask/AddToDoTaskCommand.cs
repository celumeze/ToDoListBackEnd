using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Application.Feature.Commands.AddToDoTask
{
    public class AddToDoTaskCommand : IRequest<Guid>
    {
        public Guid ToDoTaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

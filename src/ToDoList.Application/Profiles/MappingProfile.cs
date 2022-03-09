using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Feature.Commands.AddToDoTask;
using ToDoList.Application.Feature.Commands.DeleteToDoTask;
using ToDoList.Application.Feature.Queries.GetToDoTaskList;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoTask, ToDoTaskListVm>().ReverseMap();
            CreateMap<ToDoTask, AddToDoTaskCommand>().ReverseMap();
            CreateMap<ToDoTask, DeleteToDoTaskCommand>().ReverseMap();
        }
    }
}

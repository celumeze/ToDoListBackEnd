using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Application.Feature.Queries.GetToDoTaskList
{
    public class ToDoTaskListVm
    {
        public Guid ToDoTaskId { get; set; }
        public string Description { get; set; }

        public DateTime LastUpdatedDate { get;set; }
    }
}

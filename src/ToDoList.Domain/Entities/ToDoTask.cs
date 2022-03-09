using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Common;

namespace ToDoList.Domain.Entities
{
    public class ToDoTask : AuditableEntity
    {
        public Guid ToDoTaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

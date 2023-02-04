using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.TaskDTO
{
    public class AddTaskDTO
    {
        public string TaskName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool ISDelete { get; set; }
        public int FKUserID { get; set; }

    }
}

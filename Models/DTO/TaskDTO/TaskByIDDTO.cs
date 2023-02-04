using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.TaskDTO
{
    public class TaskByIDDTO
    {
        public int TaskID { get; set; }

        public string TaskName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool ISDelete { get; set; }
        public int FKUserID { get; set; }

    }
}

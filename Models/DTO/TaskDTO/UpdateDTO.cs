﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.TaskDTO
{
    public class UpdateDTO
    {
        public int PKTaskID { get; set; }
        public string TaskName { get; set; }
        
       
        public int FKUserID { get; set; }
    }
}

using Models.DTO.TaskDTO;
using Models.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.TaskRepository
{
    public interface ITaskRepository
    {
        Task<List<TaskDTO>> GetAllTask();
        Task<List<TaskByIDDTO>> GetTaskBYId(int ID);
        Task UpdateTask(UpdateDTO user);
        Task DeleteTask(int ID);
        Task<bool> AddTask(AddTaskDTO user);
    }
}

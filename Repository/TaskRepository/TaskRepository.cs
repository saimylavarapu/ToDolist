using EFCore;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO.TaskDTO;
using Models.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Repository.TaskRepository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddTask(AddTaskDTO user)
        {
            try
            {
                var iteam = new ToDoTask();
                iteam.TaskName = user.TaskName;
                iteam.IsActive = user.IsActive;
                iteam.ISDelete= user.ISDelete;
                iteam.CreatedDate = user.CreatedDate;
                iteam.FKUserID = user.FKUserID;

                await _context.tasks.AddRangeAsync(iteam);
                await _context.SaveChangesAsync();
                return true;



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteTask(int ID)
        {
            var iteam = await _context.tasks.Where(x => x.TaskID == ID && x.IsActive).FirstOrDefaultAsync();
            if (iteam != null)
            {
                iteam.IsActive = false;
                iteam.ISDelete = true;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ApplicationException("task not found");
            }

        }

        public Task<List<TaskDTO>> GetAllTask()
        {
            try
            {

                var task = _context.tasks.Where(x=>x.IsActive && !x.ISDelete).Select(x => new TaskDTO
                {
                    TaskID = x.TaskID,  
                    TaskName = x.TaskName,
                    IsActive = x.IsActive,
                    ISDelete = x.ISDelete,
                    CreatedDate = x.CreatedDate,
                    FKUserID=x.FKUserID
                }).ToListAsync();
                return task;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TaskByIDDTO>> GetTaskBYId(int ID)
        {

            var USER = await _context.tasks.Where(X => X.TaskID == ID).Select(X => new TaskByIDDTO
            {
                TaskID = X.TaskID,
                TaskName = X.TaskName,
                CreatedDate = X.CreatedDate,
                ISDelete = X.ISDelete,
                IsActive = X.IsActive


            }).ToListAsync();
            return USER;
        }

        public async Task UpdateTask(UpdateDTO taskk)
        {
            var iteam = await _context.tasks.Where(x => x.TaskID == taskk.PKTaskID && x.IsActive).FirstOrDefaultAsync();
            if(iteam!= null)
            {
                iteam.TaskName=taskk.TaskName;
                iteam.CreatedDate = taskk.CreatedDate;
                iteam.FKUserID = taskk.FKUserID;
                iteam.IsActive = true;
                iteam.ISDelete = true;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ApplicationException("task not found");
            }
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.TaskDTO;
using Models.DTO.UserDTO;
using Repository.TaskRepository;
using Repository.UserRepository;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
    // TasK Controller 
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _TaskRepo;
        public TaskController(ITaskRepository TaskRepo)
        {
            _TaskRepo = TaskRepo;
        }
        //Get All Tasks
        [HttpGet]
        [Route("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var user = await _TaskRepo.GetAllTask();
                return Ok(user);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get By ID Task
        [HttpGet]
        [Route("GetByID")]
        public async Task<List<TaskByIDDTO>> GetByID(int id)
        {
            try
            {
                var user =await _TaskRepo.GetTaskBYId(id);
                return user;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Update Task
        [HttpPut]
        [Route("UpdateTask")]
        public async Task<IActionResult> UpdateTask(UpdateDTO iteam)
        {
            if (ModelState.IsValid)
            {
               await _TaskRepo.UpdateTask(iteam);
                return Ok();
            }
            else { return BadRequest(); }
        }


        //Delete Task
        [HttpDelete]
        [Route("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                await _TaskRepo.DeleteTask(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ADD Iteams
        [HttpPost]
        [Route("AddIteam")]
        public async Task<IActionResult> AddIteam(AddTaskDTO iteam)
        {
            if (ModelState.IsValid)
            {
                await _TaskRepo.AddTask(iteam);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskList.Repository;
using TaskList.Models;

namespace TaskList.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class TasksController : ControllerBase
    {

        ITaskListRepository _repo;

        public TasksController(ITaskListRepository tasksRepo) {
            _repo = tasksRepo;
        }        

        // GET api/tasks
        [HttpGet]
        [ProducesResponseType(typeof(List<TaskItem>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> TaskItem()
        {
            try
            {
                var taskList = await _repo.GetTaskListAsync();
                return Ok(taskList);
            }
            catch (Exception exp)
            {
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // GET api/tasks/5
        [HttpGet("{id}", Name="GetTaskRoute")]
        public async Task<ActionResult> TaskItem(int id)
        {
            try
            {
                var taskItem = await _repo.GetTaskAsync(id);
                return Ok(taskItem);
            }
            catch (Exception exp)
            {
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // POST api/tasks
        [HttpPost]
        public async Task<ActionResult> CreateTask([FromBody]TaskItem task)
        {
            try
            {
                var newTask = await _repo.InsertTaskAsync(task);
                if (newTask == null)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return CreatedAtRoute("GetTaskRoute", new { id = newTask.TaskId },
                        new ApiResponse { Status = true, TaskItem = newTask });
            }
            catch (Exception exp)
            {
                return BadRequest(new ApiResponse { Status = false });
            }            
        }

        // PUT api/tasks/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id, [FromBody]TaskItem task)
        {
            try
            {
                var status = await _repo.UpdateTaskAsync(task);
                if (!status)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return Ok(new ApiResponse { Status = true, TaskItem = task });
            }
            catch (Exception exp)
            {
                return BadRequest(new ApiResponse { Status = false });
            }            
        }

        // DELETE api/tasks/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

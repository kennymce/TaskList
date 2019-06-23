using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskList.Repository;
using TaskList.Models;

namespace TaskListStatus.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class TaskListStatusController : ControllerBase
    {

        ITaskListStatusRepository _repo;

        public TaskListStatusController(ITaskListStatusRepository tasksStatusRepo) {
            _repo = tasksStatusRepo;
        }        

        // GET api/taskstatus
        [HttpGet]
        [ProducesResponseType(typeof(List<TaskItem>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> TaskItem()
        {
            try
            {
                var taskList = await _repo.GetTaskListStatusAsync();
                return Ok(taskList);
            }
            catch (Exception exp)
            {
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // GET api/taskstatus/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

    }
}

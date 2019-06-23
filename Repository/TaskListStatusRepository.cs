using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using TaskList.Models;

namespace TaskList.Repository
{
    public class TaskListStatusRepository : ITaskListStatusRepository
    {

        private readonly TaskListDatabaseContext _Context;

        public TaskListStatusRepository(TaskListDatabaseContext context) {
          _Context = context;
        }

        public async Task<List<TaskListStatusItem>> GetTaskListStatusAsync()
        {
            return await _Context.TaskListStatus.OrderBy(c => c.TaskStatusId).ToListAsync();
        }

        public async Task<TaskListStatusItem> GetTaskListStatusAsync(int id)
        {
            return await _Context.TaskListStatus.SingleOrDefaultAsync(c => c.TaskStatusId == id);
        }
    }
}
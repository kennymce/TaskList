using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using TaskList.Models;

namespace TaskList.Repository
{
    public class TaskListRepository : ITaskListRepository
    {

        private readonly TaskListDatabaseContext _Context;

        public TaskListRepository(TaskListDatabaseContext context) {
          _Context = context;
        }

        public async Task<List<TaskItem>> GetTaskListAsync()
        {
            return await _Context.TaskList.OrderBy(c => c.DateTimeCreated).ToListAsync();
        }

        public async Task<TaskItem> GetTaskAsync(int id)
        {
            return await _Context.TaskList.SingleOrDefaultAsync(c => c.TaskId == id);
        }

        public async Task<TaskItem> InsertTaskAsync(TaskItem taskItem)
        {
            _Context.Add(taskItem);
            try
            {
              await _Context.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
              throw exp;
            }

            return taskItem;
        }

        public async Task<bool> UpdateTaskAsync(TaskItem taskItem)
        {
            //Will update all properties of the TaskItem
            _Context.TaskList.Attach(taskItem);
            _Context.Entry(taskItem).State = EntityState.Modified;
            try
            {
              return (await _Context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
              throw exp;
            }
        }
    }
}
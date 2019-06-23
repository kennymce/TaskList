using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskList.Models;

namespace TaskList.Repository
{
    public interface ITaskListStatusRepository
    {     
        Task<List<TaskListStatusItem>> GetTaskListStatusAsync();
        Task<TaskListStatusItem> GetTaskListStatusAsync(int id);
    }
}
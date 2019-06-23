using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskList.Models;

namespace TaskList.Repository
{
    public interface ITaskListRepository
    {     
        Task<List<TaskItem>> GetTaskListAsync();
        Task<TaskItem> GetTaskAsync(int id);
        
        Task<TaskItem> InsertTaskAsync(TaskItem task);
        Task<bool> UpdateTaskAsync(TaskItem task);

    }
}
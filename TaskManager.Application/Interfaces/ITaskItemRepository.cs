using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<TaskItem?> GetTaskItemByIdAsync(int taskItemId);
        Task<List<TaskItem?>> GetAllTaskItemsAsync();
        Task CreateTaskItemAsync(TaskItem taskItem);
        Task UpdateTaskItemAsync(TaskItem taskItem);
        Task DeleteTaskItemAsync(int taskItemId);
    }
}
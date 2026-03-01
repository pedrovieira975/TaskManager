using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public class TaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public TaskItemService(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        public async Task<TaskItem?> GetTaskItemByIdAsync(int taskItemId)
        {
            return await _taskItemRepository.GetTaskItemByIdAsync(taskItemId);
        }

        public async Task<List<TaskItem?>> GetAllTaskItemsAsync()
        {             
            return await _taskItemRepository.GetAllTaskItemsAsync();
        }

        public async Task CreateTaskItemAsync(TaskItem taskItem)
        {
            if (string.IsNullOrWhiteSpace(taskItem.Title))
            {
                throw new ArgumentException("Task title cannot be empty.");
            }
            if (taskItem.DueDate < DateTime.UtcNow)
            {
                throw new ArgumentException("Due date cannot be in the past.");
            }

            await _taskItemRepository.CreateTaskItemAsync(taskItem);
        }

        public async Task UpdateTaskItemAsync(TaskItem taskItem)
        {
            var existingTaskItem = await _taskItemRepository.GetTaskItemByIdAsync(taskItem.Id) ?? throw new InvalidOperationException("Task item not found.");
            await _taskItemRepository.UpdateTaskItemAsync(taskItem);
        }

        public async Task DeleteTaskItemAsync(int taskItemId)
        {
            var existingTaskItem = await _taskItemRepository.GetTaskItemByIdAsync(taskItemId) ?? throw new InvalidOperationException("Task item not found.");
            await _taskItemRepository.DeleteTaskItemAsync(taskItemId);
        }
    }
}
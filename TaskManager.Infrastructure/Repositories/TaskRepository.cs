using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Data;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : ITaskItemRepository
    {
        private readonly TaskManagerDbContext _context;

        public TaskRepository(TaskManagerDbContext context) 
        { 
            _context = context; 
        }

        public async Task<TaskItem?> GetTaskItemByIdAsync(int taskItemId)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskItemId);
        }

        public async Task<List<TaskItem?>> GetAllTaskItemsAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task CreateTaskItemAsync(TaskItem taskItem)
        {
            _context.Tasks.Add(taskItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskItemAsync(TaskItem taskItem)
        {
            _context.Tasks.Update(taskItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskItemAsync(int taskItemId)
        {
            var taskItem = await GetTaskItemByIdAsync(taskItemId);
            if (taskItem != null)
            {
                _context.Tasks.Remove(taskItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public TaskStatus Status { get; private set; }

        // Relationship with User
        public int UserId { get; private set; }
        public User User { get; private set; }

        private TaskItem() { }
        public TaskItem(string title, string description, DateTime dueDate, int userId)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = TaskStatus.Pending;
            UserId = userId;
        }
        public void MarkInProgress()
        {
            Status = TaskStatus.InProgress;
        }

        public void MarkCompleted()
        {
            Status = TaskStatus.Completed;
        }
    }
}
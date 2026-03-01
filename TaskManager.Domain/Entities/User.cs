using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        private readonly List<TaskItem> _tasks = new();
        public IReadOnlyCollection<TaskItem> Tasks => _tasks.AsReadOnly();

        private User() { }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void AddTask(TaskItem task)
        {
            _tasks.Add(task);
        }
    }
}
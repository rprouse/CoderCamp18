using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CoderCamp18.Model
{
    public interface ITaskContext : IDisposable
    {
        DbSet<Task> Tasks { get; set; }
        IEnumerable<Task> GetAllTasks();
        int SaveChanges();
    }
}
using DevTrack.Data;
using DevTrack.Entities;

namespace DevTrack.Services
{
    public interface ITaskService
    {
        // []Create
        Task Create(Task task);
        // []GetAll
        // []GetById
        // []Update
        // []Delete
    }
    public class TaskService : ITaskService
    {
        private DataContext _context;

        public TaskService(DataContext context)
        {
            _context = context;
        }
        public Task Create(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }
    }
}
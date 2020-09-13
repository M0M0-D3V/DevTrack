using DevTrack.Data;

namespace DevTrack.Services
{
    public interface ITaskService
    {
        // []Create
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
    }
}
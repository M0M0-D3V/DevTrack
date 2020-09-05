using System.Collections.Generic;
using DevTrack.Data;
using DevTrack.Entities;

namespace DevTrack.Services
{
    public interface IProjectService
    {
        Project Create(Project project);
        // IEnumerable<Project> GetAll();
        // Project GetById(int id);
        // Project Update(Project project);
        // void Delete(int id);
    }
    public class ProjectService : IProjectService
    {
        private DataContext _context;

        public ProjectService(DataContext context)
        {
            _context = context;
        }
        public Project Create(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }
    }
}
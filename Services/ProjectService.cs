using System;
using System.Collections.Generic;
using System.Linq;
using DevTrack.Data;
using DevTrack.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Services
{
    public interface IProjectService
    {
        Project Create(Project project);
        IEnumerable<Project> GetAll();
        Project GetById(int id);
        Project Update(Project project);
        int Delete(int id);
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
        public IEnumerable<Project> GetAll()
        {
            List<Project> AllProjects = _context.Projects.ToList();
            return AllProjects;
        }
        public Project GetById(int id)
        {
            Project ThisProject = _context.Projects
            .Include(t => t.Tasks)
            .FirstOrDefault(p => p.ProjectId == id);
            return ThisProject;
        }
        public Project Update(Project project)
        {
            Project thisProject = _context.Projects.
            FirstOrDefault(p => p.ProjectId == project.ProjectId);
            thisProject.Description = project.Description;
            thisProject.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            Console.WriteLine("********SAVING PROJ DESCRIPTION ******");
            return thisProject;
        }
        public int Delete(int id)
        {
            Project thisProject = _context.Projects.SingleOrDefault(p => p.ProjectId == id);
            int thisWorkspaceId = thisProject.WorkspaceId;
            _context.Projects.Remove(thisProject);
            _context.SaveChanges();
            Console.WriteLine("********SUCCESS DELETING PROJECT **********");
            return thisWorkspaceId;
        }
    }
}
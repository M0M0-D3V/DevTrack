using System.Collections.Generic;
using DevTrack.Data;
using DevTrack.Entities;
using Microsoft.AspNetCore.Http;

namespace DevTrack.Services
{
    public interface IWorkspaceService
    {
        Workspace Create(Workspace workspace);
        IEnumerable<Workspace> GetAll();

    }
    public class WorkspaceService : IWorkspaceService
    {
        private DataContext _context;

        public WorkspaceService(DataContext context)
        {
            _context = context;
        }

        public Workspace Create(Workspace workspace)
        {
            _context.Workspaces.Add(workspace);
            _context.SaveChanges();
            return workspace;
        }
        public IEnumerable<Workspace> GetAll()
        {
            return _context.Workspaces;
        }
    }
}
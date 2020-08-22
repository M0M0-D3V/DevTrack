using DevTrack.Data;
using DevTrack.Entities;

namespace DevTrack.Services
{
    public interface IWorkspaceService
    {
        Workspace Create(Workspace workspace);
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
    }
}
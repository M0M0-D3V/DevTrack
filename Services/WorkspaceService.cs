using System;
using System.Collections.Generic;
using System.Linq;
using DevTrack.Data;
using DevTrack.Entities;
using Microsoft.AspNetCore.Http;

namespace DevTrack.Services
{
    public interface IWorkspaceService
    {
        Workspace Create(Workspace workspace);
        IEnumerable<Workspace> GetAll();
        Workspace GetById(int id);
        void Update(Workspace workspace);

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
        public Workspace GetById(int id)
        {
            return _context.Workspaces.Find(id);
        }
        public void Update(Workspace workspace)
        {
            Workspace thisWorkspace = _context.Workspaces.Find(workspace.WorkspaceId);

            thisWorkspace.Description = workspace.Description;
            thisWorkspace.UpdatedAt = DateTime.Now;
            // _context.Workspaces.Update(thisWorkspace);
            _context.SaveChanges();
            Console.WriteLine("*****GOT THE MESSAGE");
        }
    }
}
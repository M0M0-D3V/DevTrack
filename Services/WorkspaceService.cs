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
        Workspace Update(Workspace workspace);
        void Delete(int id);

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
        public Workspace Update(Workspace workspace)
        {
            Workspace thisWorkspace = _context.Workspaces.FirstOrDefault(ws => ws.WorkspaceId == workspace.WorkspaceId);
            // Workspace thisWorkspace = _context.Workspaces.Find(workspace.WorkspaceId);
            thisWorkspace.Description = workspace.Description;
            thisWorkspace.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            Console.WriteLine("*****GOT THE MESSAGE***");
            return thisWorkspace;
        }
        public void Delete(int id)
        {
            Workspace thisWorkspace = _context.Workspaces.SingleOrDefault(w => w.WorkspaceId == id);
            _context.Workspaces.Remove(thisWorkspace);
            _context.SaveChanges();
            Console.WriteLine("*****JOB DONE*****");
        }
    }
}
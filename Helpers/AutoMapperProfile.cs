using AutoMapper;
using DevTrack.Entities;
using DevTrack.Models.Users;
using DevTrack.Models.Orgs;
using DevTrack.Models.Workspaces;
using DevTrack.Models.Projects;
using DevTrack.Models.Tasks;

namespace DevTrack.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<source, destination>();
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();

            CreateMap<Organization, OrganizationModel>();
            CreateMap<NewOrgModel, Organization>();
            CreateMap<UpdateOrgModel, Organization>();

            CreateMap<Workspace, WorkspaceModel>();
            CreateMap<NewWorkspaceModel, Workspace>();
            CreateMap<UpdateWorkspaceModel, Workspace>();

            CreateMap<Project, ProjectModel>();
            CreateMap<NewProjectModel, Project>();
            CreateMap<UpdateProjectModel, Project>();

            CreateMap<Task, TaskModel>();
            CreateMap<NewTaskModel, Task>();
            CreateMap<UpdateTaskModel, Task>();
        }
    }
}
using AutoMapper;
using DevTrack.Entities;
using DevTrack.Models.Users;
using DevTrack.Models.Orgs;

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
        }
    }
}
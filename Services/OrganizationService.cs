using DevTrack.Data;
using DevTrack.Entities;

namespace DevTrack.Services
{
    public interface IOrganizationService
    {
        Organization Create(Organization organization);
    }
    public class OrganizationService : IOrganizationService
    {
        private DataContext _context;

        public OrganizationService(DataContext context)
        {
            _context = context;
        }

        public Organization Create(Organization organization)
        {
            _context.Organizations.Add(organization);
            _context.SaveChanges();
            return organization;
        }
    }
}
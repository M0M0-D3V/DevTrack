using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevTrack.Entities;

namespace DevTrack.Models.Orgs
{
    public class OrganizationModel
    {
        [Key]
        public int OrgId { get; set; }
        public string Name { get; set; }
        public List<Member> Members { get; set; }
    }
}
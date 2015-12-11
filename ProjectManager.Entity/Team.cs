using System;
using System.Collections.Generic;
using ProjectManager.Entity.Identity;

namespace ProjectManager.Entity
{
    public class Team : Abstract.Entity
    {
        public Team()
        {
            Id = Guid.NewGuid();

            Users = new List<ApplicationUser>();
        }


        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}

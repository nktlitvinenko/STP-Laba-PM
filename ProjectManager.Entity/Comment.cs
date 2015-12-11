using System;
using ProjectManager.Entity.Identity;

namespace ProjectManager.Entity
{
    public class Comment : Abstract.Entity
    {
        public Comment()
        {
            Id = Guid.NewGuid();
        }


        public string Text { get; set; }
        public ApplicationUser Author { get; set; }
        public Issue Issue { get; set; }
    }
}

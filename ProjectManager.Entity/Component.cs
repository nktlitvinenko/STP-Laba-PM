using System;
using System.Collections.Generic;

namespace ProjectManager.Entity
{
    public class Component : Abstract.Entity
    {
        public Component()
        {
            Id = Guid.NewGuid();

            Issues = new List<Issue>();
        }


        public string Name { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}

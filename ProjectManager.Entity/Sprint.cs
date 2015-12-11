using System;
using System.Collections.Generic;

namespace ProjectManager.Entity
{
    public class Sprint : Abstract.Entity
    {
        public Sprint()
        {
            Id = Guid.NewGuid();

            Issues = new List<Issue>();
        }


        public string Name { get; set; }

        public Project Project { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}

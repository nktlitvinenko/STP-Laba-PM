using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class SprintRepository : GenericRepository<Sprint>, ISprintRepository
    {
        public SprintRepository(IDataContext context) : base(context) { }
    }
}

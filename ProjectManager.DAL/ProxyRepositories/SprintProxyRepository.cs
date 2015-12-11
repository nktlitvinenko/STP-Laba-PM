using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.DAL.ProxyRepositories;
using ProjectManager.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class SprintProxyRepository : GenericProxyRepository<Sprint>, ISprintRepository
    {
        public SprintProxyRepository(IGenericRepository<Sprint> context) : base(context) { }
    }
}

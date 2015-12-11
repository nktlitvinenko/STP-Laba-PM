using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.DAL.ProxyRepositories;
using ProjectManager.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class TeamProxyRepository : GenericProxyRepository<Team>, ITeamRepository
    {
        public TeamProxyRepository(IGenericRepository<Team> context) : base(context) { }
    }
}

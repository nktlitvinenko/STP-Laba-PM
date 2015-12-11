using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.DAL.ProxyRepositories;
using ProjectManager.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class ProjectProxyRepository : GenericProxyRepository<Project>, IProjectRepository
    {
        public ProjectProxyRepository(IGenericRepository<Project> context) : base(context) { }
    }
}

using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.DAL.ProxyRepositories;
using ProjectManager.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class ComponentProxyRepository : GenericProxyRepository<Component>, IComponentRepository
    {
        public ComponentProxyRepository(IGenericRepository<Component> context) : base(context) { }
    }
}

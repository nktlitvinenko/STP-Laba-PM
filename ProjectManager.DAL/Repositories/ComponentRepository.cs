using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class ComponentRepository : GenericRepository<Component>, IComponentRepository
    {
        public ComponentRepository(IDataContext context) : base(context) { }
    }
}

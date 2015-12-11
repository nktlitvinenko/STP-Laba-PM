using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.Entity;
using ProjectManager.Entity.Identity;

namespace ProjectManager.DAL.Repositories
{
    public class RoleRepository : GenericRepository<ApplicationRole>, IRoleRepository
    {
        public RoleRepository(IDataContext context) : base(context) { }
    }
}

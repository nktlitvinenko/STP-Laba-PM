using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.Entity;
using ProjectManager.Entity.Identity;

namespace ProjectManager.DAL.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDataContext context) : base(context) { }
    }
}

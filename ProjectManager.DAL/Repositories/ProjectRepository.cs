using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(IDataContext context) : base(context) { }
    }
}

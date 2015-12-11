using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IDataContext context) : base(context) { }
    }
}

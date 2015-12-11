using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.DAL.ProxyRepositories;
using ProjectManager.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class CommentProxyRepository : GenericProxyRepository<Comment>, ICommentRepository
    {
        public CommentProxyRepository(IGenericRepository<Comment> context) : base(context) { }
    }
}

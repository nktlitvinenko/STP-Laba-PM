using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.DAL.ProxyRepositories;
using ProjectManager.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class AttachmentProxyRepository : GenericProxyRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentProxyRepository(IGenericRepository<Attachment> context) : base(context) { }
    }
}

using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class AttachmentRepository : GenericRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(IDataContext context) : base(context) { }
    }
}

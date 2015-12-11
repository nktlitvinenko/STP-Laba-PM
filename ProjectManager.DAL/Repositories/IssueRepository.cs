using System;
using System.Data.Entity;
using System.Linq;
using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class IssueRepository : GenericRepository<Issue>, IIssueRepository
    {
        public IssueRepository(IDataContext context) : base(context) { }
        public IQueryable<Issue> GetFullIssueById(Guid Id)
        {
            return _context.Issues.Include(i => i.Assigne).Include(i => i.Reporter).Where(i => i.Id == Id);
        }
    }
}

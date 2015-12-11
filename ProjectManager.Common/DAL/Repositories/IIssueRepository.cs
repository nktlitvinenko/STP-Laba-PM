using System;
using System.Linq;
using ProjectManager.Entity;

namespace ProjectManager.Common.DAL.Repositories
{
    public interface IIssueRepository : IGenericRepository<Issue>
    {
        IQueryable<Issue> GetFullIssueById(Guid Id);
    }
}

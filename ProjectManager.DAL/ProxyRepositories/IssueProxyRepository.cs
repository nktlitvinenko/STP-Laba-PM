using System;
using System.Linq;
using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.DAL.ProxyRepositories;
using ProjectManager.Entity;

namespace ProjectManager.DAL.Repositories
{
    public class IssueProxyRepository : GenericProxyRepository<Issue>, IIssueRepository
    {
        private IGenericRepository<Issue> _repository; 
        public IssueProxyRepository(IGenericRepository<Issue> context, IGenericRepository<Issue> repository) : base(context)
        {
            _repository = repository;
        }

        public IQueryable<Issue> GetFullIssueById(Guid Id)
        {
            return ((IIssueRepository) _repository).GetFullIssueById(Id);
        }
    }
}

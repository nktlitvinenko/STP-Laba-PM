using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.Entity;
using ProjectManager.Entity.Identity;

namespace ProjectManager.DAL
{
    public class DataBaseFacade : IDataBaseFacade
    {
        #region Inject repositories
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly IIssueRepository _issueRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ISprintRepository _sprintRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IUserRepository _userRepository;

        private readonly IDataContext _dataContext;

        public DataBaseFacade(
            IAttachmentRepository attachmentRepository, 
            ICommentRepository commentRepository, 
            IComponentRepository componentRepository, 
            IIssueRepository issueRepository, 
            IProjectRepository projectRepository, 
            IRoleRepository roleRepository, 
            ISprintRepository sprintRepository, 
            ITeamRepository teamRepository, 
            IUserRepository userRepository, 
            IDataContext dataContext)
        {
            _attachmentRepository = attachmentRepository;
            _commentRepository = commentRepository;
            _componentRepository = componentRepository;
            _issueRepository = issueRepository;
            _projectRepository = projectRepository;
            _roleRepository = roleRepository;
            _sprintRepository = sprintRepository;
            _teamRepository = teamRepository;
            _userRepository = userRepository;
            _dataContext = dataContext;
        }
        #endregion

        private IGenericRepository<T> ChoseRepository<T>() where T : class
        {
            if (typeof (T) == typeof (Attachment))
                return _attachmentRepository as IGenericRepository<T>;
            if (typeof(T) == typeof(Comment))
                return _commentRepository as IGenericRepository<T>;
            if (typeof(T) == typeof(Component))
                return _componentRepository as IGenericRepository<T>;
            if (typeof(T) == typeof(Issue))
                return _issueRepository as IGenericRepository<T>;
            if (typeof(T) == typeof(Project))
                return _projectRepository as IGenericRepository<T>;
            if (typeof(T) == typeof(ApplicationRole))
                return _roleRepository as IGenericRepository<T>;
            if (typeof(T) == typeof(Sprint))
                return _sprintRepository as IGenericRepository<T>;
            if (typeof(T) == typeof(Team))
                return _teamRepository as IGenericRepository<T>;
            if (typeof(T) == typeof(ApplicationUser))
                return _userRepository as IGenericRepository<T>;
            else
                return null;
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            var repository = ChoseRepository<T>();
            return repository.GetAll();
        }

        public IEnumerable<T> GetBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var repository = ChoseRepository<T>();
            return repository.GetBy(predicate);
        }

        public T GetById<T>(Guid id) where T : class
        {
            var repository = ChoseRepository<T>();
            return repository.GetById(id);
        }

        public T GetById<T>(string id) where T : class
        {
            var repository = ChoseRepository<T>();
            return repository.GetById(id);
        }

        public T Add<T>(T entity) where T : class
        {
            var repository = ChoseRepository<T>();
            return repository.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            var repository = ChoseRepository<T>();
            repository.Update(entity);
        }

        public void Attach<T>(T entity) where T : class
        {
            var repository = ChoseRepository<T>();
            repository.Attach(entity);
        }

        public T Delete<T>(T entity) where T : class
        {
            var repository = ChoseRepository<T>();
            return repository.Delete(entity);
        }

        public T Delete<T>(string id) where T : class
        {
            var repository = ChoseRepository<T>();
            return repository.Delete(id);
        }

        public void Save<T>() where T : class
        {
            var repository = ChoseRepository<T>();
            repository.Save();
        }

        public IEnumerable<T> Query<T>(string query) where T : class
        {
            return ((DataContext) _dataContext).Database.SqlQuery<T>(query).ToList();
        }
    }
}

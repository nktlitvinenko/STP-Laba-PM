using System.Web;
using System.Web.Http.Dependencies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Ninject;
using Ninject.Web.Common;
using ProjectManager.Common.DAL;
using ProjectManager.Common.DAL.Repositories;
using ProjectManager.DAL;
using ProjectManager.DAL.Repositories;
using ProjectManager.Entity;
using ProjectManager.Entity.Identity;
using ProjectManager.Identity.Managers;

namespace ProjectManager.IoCManager
{
    public class NinjectDependencyResolver : NinjectScope, IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
            AddBinding();
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }

        private void AddBinding()
        {
            _kernel.Bind<IAttachmentRepository>().To<AttachmentProxyRepository>();
            _kernel.Bind<ICommentRepository>().To<CommentProxyRepository>();
            _kernel.Bind<IComponentRepository>().To<ComponentProxyRepository>();
            _kernel.Bind<IIssueRepository>().To<IssueProxyRepository>();
            _kernel.Bind<IProjectRepository>().To<ProjectProxyRepository>();
            _kernel.Bind<ISprintRepository>().To<SprintProxyRepository>();
            _kernel.Bind<ITeamRepository>().To<TeamProxyRepository>();

            _kernel.Bind<IGenericRepository<Attachment>>().To<AttachmentRepository>();
            _kernel.Bind<IGenericRepository<Comment>>().To<CommentRepository>();
            _kernel.Bind<IGenericRepository<Component>>().To<ComponentRepository>();
            _kernel.Bind<IGenericRepository<Issue>>().To<IssueRepository>();
            _kernel.Bind<IGenericRepository<Project>>().To<ProjectRepository>();
            _kernel.Bind<IGenericRepository<Sprint>>().To<SprintRepository>();
            _kernel.Bind<IGenericRepository<Team>>().To<TeamRepository>();

            _kernel.Bind<IDataContext>().To<DataContext>().InSingletonScope();

            _kernel.Bind<IDataBaseFacade>().To<DataBaseFacade>();

            _kernel.Bind<ApplicationUserManager>().ToSelf().InRequestScope();
            //_kernel.Bind<ApplicationSignInManager>().ToSelf().InRequestScope();

            _kernel.Bind<IUserStore<ApplicationUser>>().ToMethod(x => new UserStore<ApplicationUser>(x.Kernel.Get<DataContext>())).InRequestScope();
            _kernel.Bind<IAuthenticationManager>().ToMethod(x => HttpContext.Current.GetOwinContext().Authentication).InRequestScope();

            _kernel.Bind<IUserRepository>().To<UserRepository>();
            _kernel.Bind<IRoleRepository>().To<RoleRepository>();
        }
    }
}

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ProjectManager.Entity;
using ProjectManager.Entity.Identity;

namespace ProjectManager.Common.DAL
{
    public interface IDataContext
    {
        IDbSet<Issue> Issues { get; set; }
        IDbSet<Project> Projects { get; set; }
        IDbSet<Sprint> Sprints { get; set; }
        IDbSet<Team> Teams { get; set; }
        IDbSet<Comment> Comments { get; set; }
        IDbSet<Component> Components { get; set; }
        IDbSet<Attachment> Attachments { get; set; }


        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        void SaveChanges();
    }
}

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManager.Common.DAL;
using ProjectManager.Entity;
using ProjectManager.Entity.Identity;

namespace ProjectManager.DAL
{
    public class DataContext : IdentityDbContext<ApplicationUser>, IDataContext
    {
        public DataContext() : base("DataContext", throwIfV1Schema: false) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Issue>().
                HasMany<Component>(i => i.Components).
                WithMany(c => c.Issues).
                Map(up =>
                {
                    up.MapLeftKey("IssueId");
                    up.MapRightKey("ComponentId");
                    up.ToTable("IssueComponent");
                }
            );
        }

        public IDbSet<Issue> Issues { get; set; }
        public IDbSet<Project> Projects { get; set; }
        public IDbSet<Sprint> Sprints { get; set; }
        public IDbSet<Team> Teams { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Component> Components { get; set; }
        public IDbSet<Attachment> Attachments { get; set; }


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public new DbEntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}

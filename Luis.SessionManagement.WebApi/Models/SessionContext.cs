using System.Data.Entity;

namespace Luis.SessionManagement.WebApi.Models
{
    public class SessionContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SessionContext() : base("name=SessionContext")
        {
        }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Presenter> Presenters { get; set; }

        public DbSet<SessionLevel> SessionLevels { get; set; }

        public DbSet<SessionCategory> SessionCategories { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<SessionPresenter> SessionPresenters { get; set; }
    
    }
}

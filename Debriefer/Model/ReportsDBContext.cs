using Microsoft.EntityFrameworkCore;

namespace Debriefer.Model
{
    public class ReportsDBContext : DbContext
    {

        public ReportsDBContext() : base()
        {
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Force> Forces { get; set; }
        public virtual DbSet<Scenario> Scenarios { get; set; }
        public virtual DbSet<Round> Rounds { get; set; }
        private readonly string AccountEndpoint = "https://localhost:8081";
        private readonly string AccountKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private readonly string DatabaseName = "AfterActionReports";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseCosmos(AccountEndpoint, AccountKey, DatabaseName);
                optionsBuilder.UseLazyLoadingProxies();
            }
        }
    }
}

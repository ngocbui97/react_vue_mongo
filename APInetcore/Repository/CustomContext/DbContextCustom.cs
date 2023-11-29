using Microsoft.EntityFrameworkCore;
using Repository.EF;


namespace Repository.CustomContext
{
    public class DbContextCustom : ticketContext
    {
        public DbContextCustom()
        {
        }

        public DbContextCustom(DbContextOptions<ticketContext> options)
            : base(options)
        {
        }
        //public DbSet<EInteractionDetail> InteractionDetails { get; set; }
        //public DbSet<InteractionWithCustomerInfo> InteractionWithCustomerInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EInteractionDetail>().HasNoKey();

            //modelBuilder.Entity<InteractionWithCustomerInfo>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

    }
}

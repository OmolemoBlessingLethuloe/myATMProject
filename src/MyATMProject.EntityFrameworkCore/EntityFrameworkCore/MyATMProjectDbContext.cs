using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyATMProject.Authorization.Roles;
using MyATMProject.Authorization.Users;
using MyATMProject.MultiTenancy;
using MyATMProject.Domains;

namespace MyATMProject.EntityFrameworkCore
{
    public class MyATMProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MyATMProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Person> Persons { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BankAccount_Transaction> BankAccount_Transactions { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Withdraw> Withdrawals { get; set; }
        //public DbSet<Transfer> Transfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Admin>("Admin")
                .HasValue<Client>("Client");
            modelBuilder.Entity<Person>()
                .Property("UserType")
                .IsRequired();


            modelBuilder.Entity<Transaction>()
                .HasDiscriminator<string>("TransactionType")
                .HasValue<Deposit>("Deposit")
                .HasValue<Withdraw>("Withdraw");
                //.HasValue<Transfer>("Transfer");
            modelBuilder.Entity<Transaction>()
                .Property("TransactionType")
                .IsRequired();
        }

        public MyATMProjectDbContext(DbContextOptions<MyATMProjectDbContext> options)
            : base(options)
        {
        }


    }
}

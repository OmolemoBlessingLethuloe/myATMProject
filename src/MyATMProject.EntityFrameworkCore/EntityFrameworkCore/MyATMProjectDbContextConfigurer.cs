using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyATMProject.EntityFrameworkCore
{
    public static class MyATMProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyATMProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyATMProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

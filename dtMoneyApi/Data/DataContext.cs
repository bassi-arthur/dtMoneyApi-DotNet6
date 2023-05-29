using dtMoneyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace dtMoneyApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using CQRSBankSystem.Data.Models;

namespace CQRSBankSystem.Data.DBContext
{
    public class CQRSBankSystemContext : DbContext
    {
        public CQRSBankSystemContext(DbContextOptions<CQRSBankSystemContext> options):base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MoneyTransfer> MoneyTransfers { get; set; }
    }
}

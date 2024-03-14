using KMCAA.Models;
using Microsoft.EntityFrameworkCore;

namespace KMCAA.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MemberDetail> MembersDetail { get; set; } = null!;
        public virtual DbSet<LookUp> LookUps{ get; set; } = null!;
        public virtual DbSet<Finance> Finances { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
              //  optionsBuilder.UseSqlServer("server=DESKTOP-K0UD4SR\\SQLEXPRESS;Initial Catalog=KMCAA-DB;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("server=203.99.63.99,1433;Initial Catalog=KMCAA-DB;User ID=cwdpak; Password=cwdmis2023#");
            }
        }
    }
}

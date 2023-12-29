using CharityClinic.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;
using System.Xml;

namespace Recruit.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<NewsDb> News { get; set; }
        public DbSet<SuVu> SuVus { get; set; }
        public DbSet<ChamSoc> ChamSocs { get; set; }
        public DbSet<KhamChuaBenh> KhamChuaBenhs { get; set; }
        public DbSet<NguoiBenLe> NguoiBenLes { get; set; }
        public DbSet<SucKhoe> SucKhoes { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<DanhMucImage> DanhMucImages { get; set; }
        public DbSet<SlideImage> SlideImages { get; set; }
        public DbSet<GioiThieu> GioiThieus { get; set; }
        public DbSet<LichSu> LichSus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ChamCongLineDb>(builder =>
            //{
            //    builder.HasNoKey();
            //});
            modelBuilder.Entity<NewsDb>().ToTable("News");
            modelBuilder.Entity<NewsDb>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<DanhMucImage>().HasMany(e => e.ImageList)
            .WithOne(e => e.DanhMucImage)
            .HasForeignKey(e => e.DanhMucImageId)
            .IsRequired();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
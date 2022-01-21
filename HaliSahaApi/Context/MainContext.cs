using Microsoft.EntityFrameworkCore;
using HaliSahaApi.Models;

namespace HaliSahaApi.Context
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        { }
        public DbSet<Posts>? PostItems => Set<Posts>();
        public DbSet<Members> MemberItems => Set<Members>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("Host=localhost;Database=halisaha;Username=postgres;Password=1234");
    }
}

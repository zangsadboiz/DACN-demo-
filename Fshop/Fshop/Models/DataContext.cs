using Fshop.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Fshop.Models
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
		public DbSet<AdminMenu> AdminMenus { get; set; }
		public DbSet<AdminUser> AdminUsers { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<About> Abouts { get; set; }
		public DbSet<Founder> Founders { get; set; }
	}
}



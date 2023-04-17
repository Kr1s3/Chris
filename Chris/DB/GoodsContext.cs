using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Chris.DB
{
	internal class GoodsContext
	{
		public DbSet<Good> Goods { get; set; }
		public DbSet<Category> Category { get; set; }

		private string _path = "goods.db";
		public GoodsContext()
		{
			if (File.Exists(_path))
			{
				Database.Migrate();
			}
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite($"Data Source = {_path}");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category()
				{
					IdCategory = Guid.NewGuid(),
					Name = "Овощи"
				},
				new Category()
				{
					IdCategory = Guid.NewGuid(),
					Name = "Фрукты"
				}
				);
		}
	}
}

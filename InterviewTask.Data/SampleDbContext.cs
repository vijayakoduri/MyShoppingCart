using InterviewTask.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewTask.Data
{
	public class SampleDbContext : DbContext
	{
		public SampleDbContext(DbContextOptions<SampleDbContext> options)
		: base(options)
		{
		}

		public DbSet<Product> Product { get; set; }

		public DbSet<ProductGallery> ProductGalleries { get; set; }

		public DbSet<ProductVariant> ProductVariants { get; set; }

		public DbSet<Item> Items { get; set; }
	}
}
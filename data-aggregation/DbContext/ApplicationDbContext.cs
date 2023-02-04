using System;
using data_aggregation.Services;
using Microsoft.EntityFrameworkCore;

namespace data_aggregation
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
		{
			
		}
		public DbSet<Apartment> Apartments { get; set; }
		public DbSet<ApartmentAggregated> ApartmentsAggregated { get; set; }
	}
}


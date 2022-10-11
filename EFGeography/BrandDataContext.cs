using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGeography
{
    public class BrandDataContext : DbContext
    {
        public BrandDataContext(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=127.0.0.1,1433;Database=dbprodcopy;Trusted_Connection=True;Integrated Security=false;User id=sa;Password=akK8tu0vNcJG6aBfHV52",
                x => x.UseNetTopologySuite());
        }

        //var builder = new DbContextOptionsBuilder<SpireDataContext>();
        ////builder.UseSqlServer("Server=tcp:ooc-west-europe.database.windows.net,1433;Initial Catalog=SpireHealthcareTest;Persist Security Info=False;User ID=SpireHealthcareTestUser;Password=KDz9sT6stNREAqRN38jp;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //builder.UseSqlServer("Server=127.0.0.1,1433;Database=dbprodcopy;Trusted_Connection=True;Integrated Security=false;User id=sa;Password=akK8tu0vNcJG6aBfHV52");
        //    //builder.UseSqlServer("Server=tcp:ooc-west-europe.database.windows.net,1433;Initial Catalog=spire-healthcare-prod;Persist Security Info=False;User ID=spire-healthcare-prod-user;Password=MwfKJT5NLTFT3TKGvgKQ;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    //builder.UseSqlServer("Server=127.0.0.1,1433;Database=SpireHealthcareTest;Trusted_Connection=True;Integrated Security=false;User id=sa;Password=akK8tu0vNcJG6aBfHV52");
        //    return new SpireDataContext(builder.Options);
    }
}
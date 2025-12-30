using Microsoft.EntityFrameworkCore;
using Repository;
namespace Tests
{
    public class DbFixture : IDisposable
    {
        public WebApiShop216328971Context Context { get; }

        public DbFixture()
        {
            var options = new DbContextOptionsBuilder<WebApiShop216328971Context>()
                .UseSqlServer("Server=DESKTOP-G2FEMDQ;Database=Shop_Test;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;

            Context = new WebApiShop216328971Context(options);

            // יצירת DB נקי
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            // סוגרים בסוף כל מחלקת טסטים
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }

}

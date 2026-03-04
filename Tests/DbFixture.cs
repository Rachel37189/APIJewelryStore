<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository;

=======
﻿using Microsoft.EntityFrameworkCore;
using Repository;
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
namespace Tests
{
    public class DbFixture : IDisposable
    {
<<<<<<< HEAD
        public WebApiShop_215602996Context Context { get; }

        public DbFixture()
        {
            var options = new DbContextOptionsBuilder<WebApiShop_215602996Context>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Shop_Test;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;

            Context = new WebApiShop_215602996Context(options);
=======
        public WebApiShop216328971Context Context { get; }

        public DbFixture()
        {
            var options = new DbContextOptionsBuilder<WebApiShop216328971Context>()
                .UseSqlServer("Server=DESKTOP-G2FEMDQ;Database=Shop_Test;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;

            Context = new WebApiShop216328971Context(options);
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca

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
<<<<<<< HEAD
    }
=======

}
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca

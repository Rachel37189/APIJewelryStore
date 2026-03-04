using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using Moq;
using Moq.EntityFrameworkCore;

=======
using Moq.EntityFrameworkCore;

using Moq;

>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
namespace Tests
{
    public class TestBase
    {
<<<<<<< HEAD
        protected Mock<TContext> GetMockContext<TContext, TEntity>(
        List<TEntity> data,
        Expression<Func<TContext, DbSet<TEntity>>> dbSetSelector
    ) where TContext : DbContext where TEntity : class
=======

        protected Mock<TContext> GetMockContext<TContext, TEntity>(
            List<TEntity> data,
            Expression<Func<TContext, DbSet<TEntity>>> dbSetSelector
        ) where TContext : DbContext where TEntity : class
>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
        {
            var mockContext = new Mock<TContext>();
            mockContext.Setup(dbSetSelector).ReturnsDbSet(data);
            return mockContext;
        }
    }
}

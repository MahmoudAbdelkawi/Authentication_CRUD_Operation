using Authentication_CRUD_Operation.Data;
using Authentication_CRUD_Operation.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Authentication_CRUD_Operation_Test
{
    public class UnitTest1
    {
        private readonly DbContextOptions<ApplicationDbContext> _context;
        public UnitTest1()
        {
            _context = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test") // connection string is ignored
                .Options;

        }
        [Fact]
        public void Test1()
        {
            // Arrange  >> declare the variables
            // Act >> operation to be tested
            // Assert >> check the result
        }
    }
}
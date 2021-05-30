using FFI.DAL;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFI.Test
{
    public class BaseTest
    {
        protected DbConnection _connection;
        protected DbContextOptions<FFIContext> _options;
        protected FFIContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            CreateInMemoryDatabase();
        }

        [TearDown]
        public void TearDown()
        {
            _connection.Dispose();
        }

        public void CreateInMemoryDatabase()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            _options = new DbContextOptionsBuilder<FFIContext>()
                .UseSqlite(_connection)
                .Options;

            _dbContext = new FFIContext(_options);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }
    }
}

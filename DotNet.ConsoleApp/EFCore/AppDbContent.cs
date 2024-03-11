using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DotNet.ConsoleApp.EFCore
{
    public class AppDbContent:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder Connection = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "DotNet",
                UserID = "sa",
                Password="sasa@123",
                TrustServerCertificate=true,
            };
            optionsBuilder.UseSqlServer(Connection.ConnectionString);
        }
        //Remain Mapping
        public DbSet<TestModel> TestModel1 { get; set; }
    }
}

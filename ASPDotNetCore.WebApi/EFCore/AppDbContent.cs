using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPDotNetCore.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASPDotNetCore.WebApi.Models;

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
    public DbSet<Model> TestModel { get; set; }
}

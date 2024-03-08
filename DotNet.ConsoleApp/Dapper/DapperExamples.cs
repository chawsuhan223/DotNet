using Dapper;
using DotNet.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ConsoleApp.Dapper
{
    public class DapperExamples
    {
        private readonly SqlConnectionStringBuilder Build = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNet",
            UserID = "sa",
           Password = "sasa@123",
            };
        public void Read()//Read
        {
            string data = @"SELECT [Id]
              ,[Name]
              ,[Address]
              ,[Description]
          FROM [dbo].[DotNetT]";
            using IDbConnection dbConnection = new SqlConnection(Build.ConnectionString);
           List<Model> lst=dbConnection.Query<Model>(data).ToList();
            foreach (Model item in lst)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Address);
                Console.WriteLine(item.Description);
            }

        }//Read

        public void Edit(int id)//Edit
        {
            string data = @"SELECT [Id]
              ,[Name]
              ,[Address]
              ,[Description]
          FROM [dbo].[DotNetT] Where [Id]= @Id";

            using IDbConnection dbConnection = new SqlConnection(Build.ConnectionString);
            var lst = dbConnection.Query<Model>(data, new {Id=id} ).FirstOrDefault();
            if (lst == null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
                Console.WriteLine(lst.Id);
                Console.WriteLine(lst.Name);
                Console.WriteLine(lst.Address);
                Console.WriteLine(lst.Description);
        }//Edit
    
        public void Create(string name,string address, string description)//Create
        {
            string data = @"INSERT INTO [dbo].[DotNetT]
           ([Name]
           ,[Address]
           ,[Description])
     VALUES
            (@Name,
            @Address,
            @Description)";


            Model lst = new Model()
            {  
                Name=name,
                Address=address,
                Description =description,
            };

            using IDbConnection dbConnection = new SqlConnection(Build.ConnectionString);
            int result = dbConnection.Execute(data,lst);

            string message = result >0 ? "Creating Successful" : "Creating Failed";
            Console.WriteLine(message);
    
        }//Create
        public void Update(int id,string name, string address, string description)//Update
        {
            string data = @"UPDATE [dbo].[DotNetT]
   SET [Name] = @Name
      ,[Address] = @Address
      ,[Description] = @Description
 WHERE Id=@Id";

            Model lst = new Model()
            {
                Id=id,
                Name = name,
                Address = address,
                Description = description,
            };

            using IDbConnection dbConnection = new SqlConnection(Build.ConnectionString);
            int result = dbConnection.Execute(data, lst);

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);

        }//Update

        public void Delete(int id)//Delete
        {
            string data = @"DELETE FROM [dbo].[DotNetT]
      WHERE [Id]=@Id";

            Model lst = new Model()
            {
                Id = id,
            };

            using IDbConnection dbConnection = new SqlConnection(Build.ConnectionString);
            int result = dbConnection.Execute(data, lst);

            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message);

        }//Delete

    }
}


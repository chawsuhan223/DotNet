using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ConsoleApp.AdoDotNet
{
    public class AdoDotNetExamples
    {
        public void Read()//Read
        {
            SqlConnectionStringBuilder Build = new SqlConnectionStringBuilder();
            Build.DataSource = ".";
            Build.InitialCatalog = "DotNet";
            Build.UserID = "sa";
            Build.Password = "sasa@123";

            string query = @"SELECT [Id]
              ,[Name]
              ,[Address]
              ,[Description]
          FROM [dbo].[DotNetT]";//Get data from table
            SqlConnection Connect = new SqlConnection(Build.ConnectionString);//Connect Database

            Connect.Open();//DataBase Open 
            Connect.Close();//Database Close

            SqlCommand Cmd = new SqlCommand(query, Connect);
            SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);
            foreach (DataRow DR in Table.Rows)
            {
                Console.WriteLine(DR["Id"]);
                Console.WriteLine(DR["Name"]);
                Console.WriteLine(DR["Address"]);
                Console.WriteLine(DR["Description"]);
            }
        }//Read

        public void Edit(int id)//Edit
        {
            SqlConnectionStringBuilder Build = new SqlConnectionStringBuilder();
            Build.DataSource = ".";
            Build.InitialCatalog = "DotNet";
            Build.UserID = "sa";
            Build.Password = "sasa@123";

            string query = @"SELECT [Id]
              ,[Name]
              ,[Address]
              ,[Description]
          FROM [dbo].[DotNetT] Where [Id]=@Id";//Get data from table
            SqlConnection Connect = new SqlConnection(Build.ConnectionString);//Connect Database
            Connect.Open();//DataBase Open 

            SqlCommand Cmd = new SqlCommand(query, Connect);
            Cmd.Parameters.AddWithValue("Id", id);
            SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            Adapter.Fill(dt);

            Connect.Close();//Database Close

            if (dt.Rows.Count==0)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            DataRow DR = dt.Rows[0];
            
                Console.WriteLine(DR["Id"]);
                Console.WriteLine(DR["Name"]);
                Console.WriteLine(DR["Address"]);
                Console.WriteLine(DR["Description"]);
           
        }//Edit

        public void Create(string name,string address,string description)//Create
        {
            SqlConnectionStringBuilder Build = new SqlConnectionStringBuilder();
            Build.DataSource = ".";
            Build.InitialCatalog = "DotNet";
            Build.UserID = "sa";
            Build.Password = "sasa@123";

            string query = @"INSERT INTO [dbo].[DotNetT]
                   ([Name]
                   ,[Address]
                   ,[Description])
 VALUES
           (@Name,
           @Address
           ,@Description)";//Insert data to table
            SqlConnection Connect = new SqlConnection(Build.ConnectionString);//Connect Database
            Connect.Open();//DataBase Open 

            SqlCommand Cmd = new SqlCommand(query, Connect);
            Cmd.Parameters.AddWithValue("Name",name);
            Cmd.Parameters.AddWithValue("Address", address);
            Cmd.Parameters.AddWithValue("Description", description);
            int result = Cmd.ExecuteNonQuery();
            Connect.Close();//Database Close

            string message = result > 0 ? "Creating Successful" : "Creating Failed";
            Console.WriteLine(message);
        }//Create

        public void Update(int id,string name, string address, string description)//Update
        {
            SqlConnectionStringBuilder Build = new SqlConnectionStringBuilder();
            Build.DataSource = ".";
            Build.InitialCatalog = "DotNet";
            Build.UserID = "sa";
            Build.Password = "sasa@123";

            string query = @"UPDATE [dbo].[DotNetT]
   SET [Name] = @Name
      ,[Address] = @Address
      ,[Description] = @Description
 WHERE [Id]=@Id";//Update data to table

            SqlConnection Connect = new SqlConnection(Build.ConnectionString);//Connect Database
            Connect.Open();//DataBase Open 

            SqlCommand Cmd = new SqlCommand(query, Connect);
            Cmd.Parameters.AddWithValue("Id", id);
            Cmd.Parameters.AddWithValue("Name", name);
            Cmd.Parameters.AddWithValue("Address", address);
            Cmd.Parameters.AddWithValue("Description", description);
            int result = Cmd.ExecuteNonQuery();
            Connect.Close();//Database Close

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);
        }//Update

        public void Delete(int id)//Delete
        {
            SqlConnectionStringBuilder Build = new SqlConnectionStringBuilder();
            Build.DataSource = ".";
            Build.InitialCatalog = "DotNet";
            Build.UserID = "sa";
            Build.Password = "sasa@123";

            string query = @"DELETE FROM [dbo].[DotNetT]
      WHERE [Id]=@Id";//Delete data to table

            SqlConnection Connect = new SqlConnection(Build.ConnectionString);//Connect Database
            Connect.Open();//DataBase Open 

            SqlCommand Cmd = new SqlCommand(query, Connect);
            Cmd.Parameters.AddWithValue("Id", id);

            int result = Cmd.ExecuteNonQuery();
            Connect.Close();//Database Close

            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message);
        }//Delete
    }
}

//AdoDotNet is use ExecuteNonQuery

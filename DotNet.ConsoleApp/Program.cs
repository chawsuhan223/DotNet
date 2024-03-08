// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//ConnectionStringBuilder
using System.Data;
using System.Data.SqlClient;

//Using Query
//SqlConnectionStringBuilder Build = new SqlConnectionStringBuilder();
//Build.DataSource = ".";
//Build.InitialCatalog = "DotNet";
//Build.UserID = "sa";
//Build.Password = "sasa@123";

//string query = "select * from DotNetT";//Get data from table
//SqlConnection Connect = new SqlConnection(Build.ConnectionString);//Connect Database

//Connect.Open();//DataBase Open 
//Connect.Close();//Database Close

//SqlCommand Cmd = new SqlCommand(query, Connect);
//SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
//DataTable Table = new DataTable();
//Adapter.Fill(Table);
//foreach(DataRow DR in Table.Rows)
//{
//    Console.WriteLine(DR["Id"]);
//    Console.WriteLine(DR["Name"]);
//    Console.WriteLine(DR["Address"]);
//    Console.WriteLine(DR["Description"]);
// }

//Using SQL Sentences
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

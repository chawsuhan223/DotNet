// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//ConnectionStringBuilder
using DotNet.ConsoleApp.AdoDotNet;
using DotNet.ConsoleApp.Dapper;
using DotNet.ConsoleApp.EFCore;
using System.Data;
using System.Data.SqlClient;
using DotNet.ConsoleApp.HTTPClients;
using DotNet.ConsoleApp.Models;
using Newtonsoft.Json;
using DotNet.ConsoleApp.RestClients;
using DotNet.ConsoleApp.RefitExamples;

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
//SqlConnectionStringBuilder Build = new SqlConnectionStringBuilder();
//Build.DataSource = ".";
//Build.InitialCatalog = "DotNet";
//Build.UserID = "sa";
//Build.Password = "sasa@123";

//string query = @"SELECT [Id]
//      ,[Name]
//      ,[Address]
//      ,[Description]
//  FROM [dbo].[DotNetT]";//Get data from table
//SqlConnection Connect = new SqlConnection(Build.ConnectionString);//Connect Database

//Connect.Open();//DataBase Open 
//Connect.Close();//Database Close

//SqlCommand Cmd = new SqlCommand(query, Connect);
//SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
//DataTable Table = new DataTable();
//Adapter.Fill(Table);
//foreach (DataRow DR in Table.Rows)
//{
//    Console.WriteLine(DR["Id"]);
//    Console.WriteLine(DR["Name"]);
//    Console.WriteLine(DR["Address"]);
//    Console.WriteLine(DR["Description"]);
//}

//AdoDotNet
//AdoDotNetExamples AdoDotNet = new AdoDotNetExamples();
//AdoDotNet.Read();
//AdoDotNet.Edit(1);
//AdoDotNet.Edit(6);
//AdoDotNet.Create("KHL", "Yangon", "Clothes");
//AdoDotNet.Update(6,"KhantHtetLin", "Mandalay", "Jeans");
//AdoDotNet.Update(7,"KhantHtetLin", "Mandalay", "Jeans");
//AdoDotNet.Delete(6);

//Dapper
//DapperExamples Dapper = new DapperExamples();
//Dapper.Read();
//Dapper.Edit(1);
//Dapper.Edit(6);
//Dapper.Create("Hla Hla", "Hlaing", "Oil");
//Dapper.Update(7,"Kyaw Kyaw", "SanChaung", "T-Shirt");
//Dapper.Delete(7);

//EFCore
//EFCoreExamples Efcore = new EFCoreExamples();
//Efcore.Read();
//Efcore.Edit(1);

//Console.WriteLine("Waiting For API....");
//Console.ReadKey();
//Console.WriteLine("Hello World");
//HTTPClientExample hTTPClient = new HTTPClientExample();
//await hTTPClient.Run();

//TestModel test = new TestModel();
//test.Name = "TestName";
//test.Description = "TestDescription";
//test.Address = "TestAddress";

//string jSOn=JsonConvert.SerializeObject(test);//C# to JSON
//Console.WriteLine(test);
//Console.WriteLine(jSOn);
//Console.WriteLine(test.Name);
//Console.WriteLine(test.Description);
//Console.WriteLine(test.Address);

//TestModel model2 = JsonConvert.DeserializeObject<TestModel>(jSOn);
//Console.WriteLine(model2.Name);
//Console.WriteLine(model2.Description);
//Console.WriteLine(model2.Address);

//Console.WriteLine("Hello World");
//HTTPClientExample hTTPClient = new HTTPClientExample();
//await hTTPClient.Run();

//Console.WriteLine("Hello");
//RestClientExamples restClientExamples = new RestClientExamples();
//await restClientExamples.Run();


Console.WriteLine("Hello");

Console.ReadKey();

RefitExample refitExample = new RefitExample();

await refitExample.Run();

Console.ReadKey();
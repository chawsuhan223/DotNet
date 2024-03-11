using DotNet.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Model = DotNet.ConsoleApp.Models.Model;
namespace DotNet.ConsoleApp.EFCore
{
    public class EFCoreExamples
    {
        public void Read()
        {
            AppDbContent Db = new AppDbContent();
            List<TestModel> lst = Db.TestModel1.ToList();
            foreach(TestModel item in lst)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Address);
                Console.WriteLine(item.Description);
            }
           
        }
        public void Edit(int id)//Edit
        {
            AppDbContent db = new AppDbContent();//Because AppDbContext include SqlConnectionStringBuilder
            //TestModel Item = db.Model.Where(item => item.Id == id).FirstOrDefault();
            TestModel item = db.TestModel1.FirstOrDefault(item => item.Id == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found!");
                return;
            };
            Console.WriteLine(item.Id);
            Console.WriteLine(item.Name);
            Console.WriteLine(item.Address);
            Console.WriteLine(item.Description);
        }//Edit
    }
}

using DotNet.ConsoleApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.ConsoleApp.RefitExamples
{
    public interface IBlogAPI
    {
        [Get("/api/Model")]
        Task<List<TestModel>> GetBlog();

        [Get("/api/Model/{id}")]
        Task<TestModel> GetBlogs(int id);
    }
}

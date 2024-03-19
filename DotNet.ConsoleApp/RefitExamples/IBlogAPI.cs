using DotNet.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore.Metadata;
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

        [Post("/api/Model")]
        Task<String> CreateBlog(Model model);

        [Put("/api/Model/{id}")]
        Task<String> UpdateBlog(int id, Model model);

        [Delete("/api/Model/{id}")]
        Task<String> DeleteBlog(int id);
    }
}

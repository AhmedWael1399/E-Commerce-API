using DatabaseContext;
using DatabaseServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseServices.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CommerceDbContext _context;
        public CategoryService(CommerceDbContext context)
        {
           _context = context;
        }
        public bool CategoriesExist(int categoryId)
        {
            return _context.Categories.Any(c => c.Id == categoryId);
        }

        public Categories GetCategory(int categoryId)
        {
            return _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
        }
    }
}

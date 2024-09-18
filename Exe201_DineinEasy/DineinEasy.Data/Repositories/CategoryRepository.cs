using DineinEasy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Data.Repositories
{
    public class CategoryRepository:GenericRepository<Category>
    {
    public CategoryRepository() { }
    public CategoryRepository(EXE2_DineinEasyContext context)
        {
            _context = context;
        }
    }
}

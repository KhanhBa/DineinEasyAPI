using DineinEasy.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Data.Repositories
{
    public class NotificationRepository:GenericRepository<Notification>
    {
        public NotificationRepository() { }
        public NotificationRepository(EXE2_DineinEasyContext context)
        {
            _context = context;
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace HangFireProject.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){ }
    }
}
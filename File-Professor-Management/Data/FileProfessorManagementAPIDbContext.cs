using File_Professor_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace File_Professor_Management.Data
{
    public class FileProfessorManagementAPIDbContext : DbContext
    {
        public FileProfessorManagementAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Professor> Professors { get; set; }
    }
}

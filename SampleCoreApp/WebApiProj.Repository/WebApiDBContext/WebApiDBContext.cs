namespace WebApiProj.Repository.WebApiDBContext
{
    using Microsoft.EntityFrameworkCore;
    using WebApiProj.DataAccess.Models;

    public class WebApiDBContext : DbContext
    {
        public WebApiDBContext(DbContextOptions<WebApiDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> UsersInfo { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApiProj.DataAccess.Models;

namespace WebApiProj.Repository.WebApiDBContext
{
    /// <summary>
    /// Data Generator
    /// </summary>
    public class DataGenerator
    {
        /// <summary>
        /// Initializes the specified service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApiDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<WebApiDBContext>>()))
            {
                if (context.UsersInfo.Any())
                {
                    return;  // Data was already seeded
                }

                context.UsersInfo.AddRange(
                    new User
                    {
                        Id = "1",
                        FirstName = "Steve",
                        LastName = "Finn",
                        Country = "UK",
                        Employer = "Facebook",
                        Designation = "Senior Engineer"
                    },
                    new User
                    {
                        Id = "2",
                        FirstName = "Jack",
                        LastName = "Will",
                        Country = "Australia",
                        Employer = "Google",
                        Designation = "Consultant"
                    },
                    new User
                    {
                        Id = "3",
                        FirstName = "Viraj",
                        LastName = "Sharma",
                        Country = "India",
                        Employer = "Microsoft",
                        Designation = "Consultant"
                    },
                    new User
                    {
                        Id = "4",
                        FirstName = "Thomas",
                        LastName = "Miller",
                        Country = "US",
                        Employer = "Walmart",
                        Designation = "Program Manager"
                    },
                    new User
                    {
                        Id = "5",
                        FirstName = "Jack",
                        LastName = "Ryan",
                        Country = "US",
                        Employer = "AT&T",
                        Designation = "Senior Consultant"
                    });
                context.SaveChanges();
            }
        }
    }
}

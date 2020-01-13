using AutoMapper;
using System.Collections.Generic;
using WebApiProj.Business;

namespace WebApiProj.XUnitTestProject.Helpers
{
    /// <summary>
    /// Common Helper
    /// </summary>
    public static class CommonHelper
    {
        /// <summary>
        /// Gets the employee mapper object.
        /// </summary>
        /// <returns></returns>
        public static IMapper GetMapperObj()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            return mappingConfig.CreateMapper();
        }

        /// <summary>
        /// Gets the mocked users of database.
        /// </summary>
        /// <returns></returns>
        public static List<DataAccess.Models.User> GetMockedUsersOfDB()
        {
            List<DataAccess.Models.User> users = new List<DataAccess.Models.User>()
            {
                new DataAccess.Models.User
                    {
                        Id = "1",
                        FirstName = "Steve",
                        LastName = "Finn",
                        Country = "UK",
                        Employer = "Facebook",
                        Designation = "Senior Engineer"
                    },
                    new DataAccess.Models.User
                    {
                        Id = "2",
                        FirstName = "Jack",
                        LastName = "Will",
                        Country = "Australia",
                        Employer = "Google",
                        Designation = "Consultant"
                    },
                    new DataAccess.Models.User
                    {
                        Id = "3",
                        FirstName = "Viraj",
                        LastName = "Sharma",
                        Country = "India",
                        Employer = "Microsoft",
                        Designation = "Consultant"
                    },
                    new DataAccess.Models.User
                    {
                        Id = "4",
                        FirstName = "Thomas",
                        LastName = "Miller",
                        Country = "US",
                        Employer = "Walmart",
                        Designation = "Program Manager"
                    },
                    new DataAccess.Models.User
                    {
                        Id = "5",
                        FirstName = "Jack",
                        LastName = "Ryan",
                        Country = "US",
                        Employer = "AT&T",
                        Designation = "Senior Consultant"
                    }
        };
            return users;
        }

        /// <summary>
        /// Gets the mocked users.
        /// </summary>
        /// <returns></returns>
        public static List<Client.Models.User> GetMockedUsers()
        {
            List<Client.Models.User> users = new List<Client.Models.User>()
            {
                new Client.Models.User
                    {
                        Id = "1",
                        FirstName = "Steve",
                        LastName = "Finn",
                        Country = "UK",
                        Employer = "Facebook",
                        Designation = "Senior Engineer"
                    },
                    new Client.Models.User
                    {
                        Id = "2",
                        FirstName = "Jack",
                        LastName = "Will",
                        Country = "Australia",
                        Employer = "Google",
                        Designation = "Consultant"
                    },
                    new Client.Models.User
                    {
                        Id = "3",
                        FirstName = "Viraj",
                        LastName = "Sharma",
                        Country = "India",
                        Employer = "Microsoft",
                        Designation = "Consultant"
                    },
                    new Client.Models.User
                    {
                        Id = "4",
                        FirstName = "Thomas",
                        LastName = "Miller",
                        Country = "US",
                        Employer = "Walmart",
                        Designation = "Program Manager"
                    },
                    new Client.Models.User
                    {
                        Id = "5",
                        FirstName = "Jack",
                        LastName = "Ryan",
                        Country = "US",
                        Employer = "AT&T",
                        Designation = "Senior Consultant"
                    }
        };
            return users;
        }
    }
}

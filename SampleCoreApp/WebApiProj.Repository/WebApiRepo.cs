namespace WebApiProj.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using WebApiProj.DataAccess.Models;
    using WebApiProj.Repository.Contract;

    /// <summary>
    /// WebApi Repository
    /// </summary>
    /// <seealso cref="WebApiProj.Repository.Contract.IWebApiRepo" />
    public class WebApiRepo : IWebApiRepo
    {
        /// <summary>
        /// The database context
        /// </summary>
        private WebApiDBContext.WebApiDBContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiRepo"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public WebApiRepo(WebApiDBContext.WebApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>
        /// List of Users
        /// </returns>
        public List<User> GetUsers()
        {
            return _dbContext.UsersInfo.ToList();
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns>
        /// Response
        /// </returns>
        public bool UpdateUser(List<User> users)
        {
            try
            {
                foreach (var user in users)
                {
                    var selectedUser = _dbContext.UsersInfo.Where(x => x.Id == user.Id).FirstOrDefault();
                    selectedUser.FirstName = user.FirstName;
                    selectedUser.LastName = user.LastName;
                    selectedUser.Employer = user.Employer;
                    selectedUser.Designation = user.Designation;
                    selectedUser.Country = user.Country;

                    _dbContext.SaveChanges();
                }
                return true;
            }
            catch
            {
                //Log Exception
                return false;
            }
        }
    }
}

namespace WebApiProj.Repository.Contract
{
    using System.Collections.Generic;
    using WebApiProj.DataAccess.Models;

    /// <summary>
    /// WebApi Repository Interface
    /// </summary>
    public interface IWebApiRepo
    {
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>
        /// List of Users
        /// </returns>
        List<User> GetUsers();

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns>
        /// Response
        /// </returns>
        bool UpdateUser(List<User> users);
    }
}

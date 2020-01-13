namespace WebApiProj.Business.Contract
{
    using System.Collections.Generic;
    using WebApiProj.Client.Models;

    /// <summary>
    /// WebApi Business Interface
    /// </summary>
    public interface IWebApiBusiness
    {
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>List of Users</returns>
        List<User> GetUsers();

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns>Response</returns>
        bool UpdateUser(List<User> users);
    }
}

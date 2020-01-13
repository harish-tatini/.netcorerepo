namespace MVCAppProj.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// User View Model
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserViewModel"/> class.
        /// </summary>
        public UserViewModel()
        {
            UsersList = new List<UserModel>();
        }

        /// <summary>
        /// Gets or sets the users list.
        /// </summary>
        /// <value>
        /// The users list.
        /// </value>
        public List<UserModel> UsersList { get; set; }
    }
}

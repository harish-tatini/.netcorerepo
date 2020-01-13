namespace WebApiProj.Business
{
    using AutoMapper;
    using System.Collections.Generic;
    using WebApiProj.Business.Contract;
    using WebApiProj.Client.Models;
    using WebApiProj.Repository.Contract;

    /// <summary>
    /// WebApi Business
    /// </summary>
    /// <seealso cref="WebApiProj.Business.Contract.IWebApiBusiness" />
    public class WebApiBusiness : IWebApiBusiness
    {
        /// <summary>
        /// The web API repo
        /// </summary>
        private IWebApiRepo webApiRepo;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiBusiness"/> class.
        /// </summary>
        /// <param name="_webApiRepo">The web API repo.</param>
        /// <param name="_mapper">The mapper.</param>
        public WebApiBusiness(IWebApiRepo _webApiRepo, IMapper _mapper)
        {
            webApiRepo = _webApiRepo;
            mapper = _mapper;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>List of Users</returns>
        public List<User> GetUsers()
        {
            return mapper.Map<List<User>>(webApiRepo.GetUsers());
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns>Response</returns>
        public bool UpdateUser(List<User> users)
        {
            return webApiRepo.UpdateUser(mapper.Map<List<DataAccess.Models.User>>(users));
        }
    }
}

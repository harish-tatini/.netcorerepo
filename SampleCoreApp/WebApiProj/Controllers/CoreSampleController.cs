namespace WebApiProj.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using WebApiProj.Business.Contract;
    using WebApiProj.Client.Models;

    /// <summary>
    /// Core Sample Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class CoreSampleController : ControllerBase
    {
        /// <summary>
        /// The web API business
        /// </summary>
        private IWebApiBusiness webApiBusiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreSampleController" /> class.
        /// </summary>
        /// <param name="_webApiBusiness">The web API business.</param>
        public CoreSampleController(IWebApiBusiness _webApiBusiness)
        {
            webApiBusiness = _webApiBusiness;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>List of Users</returns>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            try
            {
                return webApiBusiness.GetUsers();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Posts the specified users.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns>Response</returns>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] List<User> users)
        {
            try
            {
                return webApiBusiness.UpdateUser(users);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}

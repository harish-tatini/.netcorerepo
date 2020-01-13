using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVCAppProj.Models;
using Newtonsoft.Json;
using RestSharp;

namespace MVCAppProj.Controllers
{
    /// <summary>
    /// HomeController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// The Web API URI
        /// </summary>
        public string apiUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
            apiUri = Configuration["WebApiUri"];
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {
            UserViewModel userViewModel = new UserViewModel();
            return View(userViewModel);
        }

        /// <summary>
        /// Gets the user data.
        /// </summary>
        /// <returns>List of User data</returns>
        [Authorize]
        [HttpPost]
        public ActionResult GetData()
        {
            var client = new RestClient(apiUri);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            var response = client.Execute(request).Content;

            UserViewModel userViewModel = new UserViewModel();
            userViewModel.UsersList = JsonConvert.DeserializeObject<List<UserModel>>(response);

            return View("Index", userViewModel);
        }

        /// <summary>
        /// Updates the users.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns>Response</returns>
        [Authorize]
        [HttpPost]
        public bool UpdateUsers(List<UserModel> users)
        {
            var client = new RestClient(apiUri);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(users), ParameterType.RequestBody);
            var response = client.Execute(request).Content;

            return true;
        }

        /// <summary>
        /// Errors this instance.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

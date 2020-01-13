namespace WebApiProj.XUnitTestProject
{
    using AutoMapper;
    using Moq;
    using System.Collections.Generic;
    using WebApiProj.Business;
    using WebApiProj.Repository.Contract;
    using WebApiProj.XUnitTestProject.Helpers;
    using Xunit;

    /// <summary>
    /// API Unit Tests
    /// </summary>
    public class APIUnitTests
    {
        /// <summary>
        /// The web API repo
        /// </summary>
        Mock<IWebApiRepo> webApiRepo = new Mock<IWebApiRepo>();

        /// <summary>
        /// The mapper
        /// </summary>
        IMapper mapper = CommonHelper.GetMapperObj();

        /// <summary>
        /// Gets the users unit test ok response.
        /// </summary>
        [Fact]
        public void GetUsersUnitTest_OkResponse()
        {
            List<DataAccess.Models.User> mockedData = CommonHelper.GetMockedUsersOfDB();
            webApiRepo.Setup(repo => repo.GetUsers()).Returns(mockedData);

            WebApiBusiness webApiBusiness = new WebApiBusiness(webApiRepo.Object, mapper);
            var result = webApiBusiness.GetUsers();

            Assert.NotNull(result);
            Assert.Equal(result[0].Id, mockedData[0].Id);
        }

        /// <summary>
        /// Gets the users unit test null response.
        /// </summary>
        [Fact]
        public void GetUsersUnitTest_NullResponse()
        {
            List<DataAccess.Models.User> mockedData = CommonHelper.GetMockedUsersOfDB();
            webApiRepo.Setup(repo => repo.GetUsers()).Returns((List<DataAccess.Models.User>)null);

            WebApiBusiness webApiBusiness = new WebApiBusiness(webApiRepo.Object, mapper);
            var result = webApiBusiness.GetUsers();

            Assert.True(result.Count == 0);
        }

        /// <summary>
        /// Updates the users unit test, returns true response.
        /// </summary>
        [Fact]
        public void UpdateUsersUnitTest_OkResponse()
         {
            List<Client.Models.User> mockedClientData = CommonHelper.GetMockedUsers();
            List<DataAccess.Models.User> mockedDataAccessData = mapper.Map<List<DataAccess.Models.User>>(mockedClientData);
            
            webApiRepo.Setup(repo => repo.UpdateUser(mockedDataAccessData)).Returns(true);

            WebApiBusiness webApiBusiness = new WebApiBusiness(webApiRepo.Object, mapper);
            var result = webApiBusiness.UpdateUser(mockedClientData);

            Assert.True(result);
        }

        /// <summary>
        /// Updates the users unit test, returns false response.
        /// </summary>
        [Fact]
        public void UpdateUsersUnitTest_FalseResponse()
        {
            List<Client.Models.User> mockedClientData = CommonHelper.GetMockedUsers();

            webApiRepo.Setup(repo => repo.UpdateUser((List<DataAccess.Models.User>)null)).Returns(true);

            WebApiBusiness webApiBusiness = new WebApiBusiness(webApiRepo.Object, mapper);
            var result = webApiBusiness.UpdateUser(mockedClientData);

            Assert.False(result);
        }
    }
}

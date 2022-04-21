using System.Threading.Tasks;
using MyATMProject.Models.TokenAuth;
using MyATMProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyATMProject.Web.Tests.Controllers
{
    public class HomeController_Tests: MyATMProjectWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
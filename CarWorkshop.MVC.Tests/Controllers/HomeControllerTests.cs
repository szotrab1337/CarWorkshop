//using FluentAssertions;
//using Microsoft.AspNetCore.Mvc.Testing;
//using System.Net;
//using Xunit;

//namespace CarWorkshop.MVC.Controllers.Tests
//{
    //Not Working
    //public class HomeControllerTests : IClassFixture<WebApplicationFactory<Program>>
    //{
    //    private readonly WebApplicationFactory<Program> _factory;

    //    public HomeControllerTests(WebApplicationFactory<Program> factory)
    //    {
    //        _factory = factory;
    //    }

    //    [Fact]
    //    public async Task About_ReturnsViewWithRenderModel()
    //    {
    //        //Arrange
    //        var client = _factory.CreateClient();

    //        //Act
    //        var response = await client.GetAsync("/Home/About");
    //        var content = await response.Content.ReadAsStringAsync();

    //        //Assert
    //        response.StatusCode.Should().Be(HttpStatusCode.OK);
    //        content.Should().Contain("<h1>About</h1>")
    //            .And.Contain("<div class=\"alert alert-danger\">Description</div>")
    //            .And.Contain("<p>Tag1</p>")
    //            .And.Contain("<p>Tag2</p>");
    //    }
    //}
//}
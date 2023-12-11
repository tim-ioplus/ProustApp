using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using ProustApp.Controllers;
using ProustApp.Domain;
using ProustApp.Services;
using Xunit;

namespace ProustApp.Tests;

public class ControllerTest
{
    [Theory]
    [InlineData("0")]
    [InlineData("1")]
    public async void Test_QuestController_Get_OK(string testQid)
    {
        var qs = new QuestDataHelper().CreateService();
        Assert.NotNull(qs);

        var controller = new QuestController(qs);
        Assert.NotNull(controller);

        var result = await controller.Get(testQid);
        Assert.NotNull(result);

        // Assert
        var type = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(type.Value);
        Assert.Equal(type.StatusCode, StatusCodes.Status200OK);
        
        var payload = type.Value as Questionnaire;
        Assert.NotNull(payload);
    }

    [Theory]
    [InlineData("47")]
    [InlineData("32148")]
    public async void Test_QuestController_Get_NotOK(string testQid)
    {
        var qs = new QuestDataHelper().CreateService();
        Assert.NotNull(qs);

        var controller = new QuestController(qs);
        Assert.NotNull(controller);

        var result = await controller.Get(testQid);
        Assert.NotNull(result);

        // Assert
        var type = Assert.IsType<NotFoundObjectResult>(result);
        Assert.NotNull(type.Value);
        Assert.Equal(type.StatusCode, StatusCodes.Status404NotFound);
        
        var payload = type.Value;
        Assert.NotNull(payload);

        Assert.Equal(payload, "Data with id {"+testQid+"} not found.");
    }

    [Fact]
    public async void Test_QuestController_ListFilledToRead()
    {
        var qs = new QuestDataHelper().CreateService();
        Assert.NotNull(qs);

        var controller = new QuestController(qs);
        Assert.NotNull(controller);

        var result = await controller.List("read");
        Assert.NotNull(result);

        // Assert
        var type = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(type.Value);
        Assert.Equal(type.StatusCode, StatusCodes.Status200OK);
        
        var payload = type.Value as List<Questionnaire>;
        Assert.NotNull(payload);

        var anyWithoutResponse = payload.Any(q => string.IsNullOrEmpty(q.ResponseAuthor));
        Assert.False(anyWithoutResponse);
    }

     [Fact]
    public async void Test_QuestController_ListUnfilledToFill()
    {
        var qs = new QuestDataHelper().CreateService();
        Assert.NotNull(qs);

        var controller = new QuestController(qs);
        Assert.NotNull(controller);

        var result = await controller.List("fill");
        Assert.NotNull(result);

        // Assert
        var type = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(type.Value);
        Assert.Equal(type.StatusCode, StatusCodes.Status200OK);
        
        var payload = type.Value as List<Questionnaire>;
        Assert.NotNull(payload);

        var anyWithoutResponse = payload.Any(q => string.IsNullOrEmpty(q.ResponseAuthor));
        Assert.True(anyWithoutResponse);
    }
}
using Microsoft.Extensions.Options;
using ProustApp.Domain;
using ProustApp.Services;
using Xunit;

namespace ProustApp.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {

    }

    [Theory]
    [InlineData(2)]
    [InlineData(4)]
    public void TestIsEven(int value)
    {
        Assert.True(IsEven(value));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    public void TestIsOdd(int value)
    {
        Assert.False(IsEven(value));
    }

    private bool IsEven(int value)
    {
        return value % 2 == 0;
    }
}
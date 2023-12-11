using Microsoft.Extensions.Options;
using MongoDB.Driver.Linq;
using ProustApp.Domain;
using ProustApp.Services;
using Xunit;

namespace ProustApp.Tests;

public class DataTest
{
    
    [Fact]
    public async void TestData()
    {
        bool _log = false;
        var qs = new QuestDataHelper().CreateService();        

        var res = await qs.ListAsync();

        foreach (var q in res)
        {
            if(_log) Console.WriteLine(q._objectId + " " + q.qid + " " + q.Author + " " + q.Topic + " " + q.ResponseAuthor);

            Assert.True(!string.IsNullOrEmpty(q.Author));
            Assert.True(q.Dialogs != null);
            Assert.True(q.Dialogs?.Any());

            if(q.Dialogs != null && q.Dialogs.Any())
            {
                foreach(var d in q.Dialogs)
                {
                    Assert.True(!string.IsNullOrEmpty(d.Question));
                    if(_log) Console.WriteLine("Q:" + d.Question);

                    if(!string.IsNullOrEmpty(q.ResponseAuthor))
                    {
                        Assert.True(!string.IsNullOrEmpty(d.Answer));
                    }

                    if(_log) Console.WriteLine("A:" + d.Answer);  
                }
            }

            if(_log) Console.WriteLine("- - -");
        }

        Assert.True(res.Any());
    }


    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public async void TestDataRead(int testQid)
    {
        var qs = new QuestDataHelper().CreateService(); 

        var qx = await qs.ReadAsync(testQid);
        Assert.True(qx != null);
        Assert.NotNull(qx);

        var dataQuid = qx?.qid;
        Assert.True(dataQuid.Equals(testQid));

        Assert.NotNull(qx?._objectId);
        Assert.NotNull(qx?.Topic);
        Assert.NotNull(qx?.Author);
        Assert.NotNull(qx?.Dialogs);         
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public async void TestDataFilter_Filled(int testQid, bool testResult)
    {
        var qs = new QuestDataHelper().CreateService(); 

        var quests = await qs.ListFilledASync();
        var dataResult = quests.Any(q => q.qid==testQid);

        Assert.True(dataResult.Equals(testResult));
    }

    [Theory]
    [InlineData(0, true)]
    [InlineData(1, false)]
    public async void TestDataFilter_Unfilled(int testQid, bool testResult)
    {
        var qs = new QuestDataHelper().CreateService(); 

        var quests = await qs.ListUnfilledAsync();
        var dataResult = quests.Any(q => q.qid==testQid);

        Assert.True(dataResult.Equals(testResult));
    }
}
using Microsoft.Extensions.Options;
using ProustApp.Domain;
using ProustApp.Services;
using Xunit;

namespace ProustApp.Tests;

public class DataTest
{
    [Fact]
    public async void TestData()
    {
        var s = new QuestStoreDatabaseSettings
        {
            ConnectionString = "mongodb://localhost:27017",
            DatabaseName = "ProustApp",
            QuestsCollectionName = "Quests"
        };

        var qs = new QuestsService(s);

        var res = await qs.ListAsync();

        foreach (var q in res)
        {
            Console.WriteLine(q._objectId + " " + q.qid + " " + q.Author + " " + q.Topic + " " + q.ResponseAuthor);
            Assert.True(!string.IsNullOrEmpty(q.Author));
            Assert.True(q.Dialogs != null);
            Assert.True(q.Dialogs?.Any());

            if(q.Dialogs != null && q.Dialogs.Any())
            {
                foreach(var d in q.Dialogs)
                {
                    Assert.True(!string.IsNullOrEmpty(d.Question));
                    Console.WriteLine("Q:" + d.Question);

                    if(!string.IsNullOrEmpty(q.ResponseAuthor))
                    {
                        Assert.True(!string.IsNullOrEmpty(d.Answer));
                    }
                    Console.WriteLine("A:" + d.Answer);
                    
                    Console.WriteLine("- - -"); 
                }
            }
        }

        Assert.True(res.Any());
    }
}
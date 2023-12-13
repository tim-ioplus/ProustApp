using ProustApp.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ProustApp.Services;

public class QuestsService
{
    private readonly IMongoCollection<Quest> _questCollection;

    public QuestsService(IOptions<QuestStoreDatabaseSettings> questStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(questStoreDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(questStoreDatabaseSettings.Value.DatabaseName);
        _questCollection = mongoDatabase.GetCollection<Quest>(questStoreDatabaseSettings.Value.QuestsCollectionName);
    }

    public QuestsService(QuestStoreDatabaseSettings questStoreDatabaseSettingValues, bool forUnitTest = false)
    {
        if(!forUnitTest) throw new Exception("Call Constructor only For UnitTesting");

        var mongoClient = new MongoClient(questStoreDatabaseSettingValues.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(questStoreDatabaseSettingValues.DatabaseName);
        _questCollection = mongoDatabase.GetCollection<Quest>(questStoreDatabaseSettingValues.QuestsCollectionName);
    }

    public async Task<List<Quest>> ListAsync(string filter="")
    {
        if(filter.Equals("read"))
        {
            var collection = await ListFilledASync();
            return collection;
        }
        if(filter.Equals("fill"))
        {
            var collection = await ListUnfilledAsync();
            return collection;
        }
        else
        {
            var collection = await _questCollection.Find(_ => true).ToListAsync();
            return collection;
        }
    }

    public async Task<List<Quest>> ListUnfilledAsync() => 
        await _questCollection.Find(x => string.IsNullOrEmpty(x.ResponseAuthor)).ToListAsync();
    
    public async Task<List<Quest>> ListFilledASync() => 
        await _questCollection.Find(x => !string.IsNullOrEmpty(x.ResponseAuthor)).ToListAsync(); 
    
    public async Task<Quest?> ReadAsync(int id) => 
        await _questCollection.Find(x => x.qid == id).FirstOrDefaultAsync();

    private async Task createAsync(Quest newQuest) =>
        await _questCollection.InsertOneAsync(newQuest);

    public async Task CreateAsync(Quest newQuest)
    {
        newQuest.guid = Guid.NewGuid().ToString();

        await createAsync(newQuest);
    }


    public async Task UpdateAsync(int id, Quest updatedQuest) =>
        await _questCollection.ReplaceOneAsync(x => x.qid==id, updatedQuest);

    public async Task DeleteAsync(int id) => 
        await _questCollection.DeleteOneAsync(x => x.qid==id);
}
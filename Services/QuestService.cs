using ProustApp.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ProustApp.Services;

public class QuestsService
{
    private readonly IMongoCollection<Questionnaire> _questCollection;

    public QuestsService(IOptions<QuestStoreDatabaseSettings> questStoreDatabaseSettings)
    {
        new QuestsService(questStoreDatabaseSettings.Value);
    }

    public QuestsService(QuestStoreDatabaseSettings questStoreDatabaseSettingValues)
    {
        var mongoClient = new MongoClient(questStoreDatabaseSettingValues.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(questStoreDatabaseSettingValues.DatabaseName);
        _questCollection = mongoDatabase.GetCollection<Questionnaire>(questStoreDatabaseSettingValues.QuestsCollectionName);
    }

    public async Task<List<Questionnaire>> ListAsync(string filter="")
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

    public async Task<List<Questionnaire>> ListUnfilledAsync() => 
        await _questCollection.Find(x => string.IsNullOrEmpty(x.ResponseAuthor)).ToListAsync();
    
    public async Task<List<Questionnaire>> ListFilledASync() => 
        await _questCollection.Find(x => !string.IsNullOrEmpty(x.ResponseAuthor)).ToListAsync(); 
    
    public async Task<Questionnaire?> ReadAsync(int id) => 
        await _questCollection.Find(x => x.qid == id).FirstOrDefaultAsync();

    private async Task createAsync(Questionnaire newQuest) =>
        await _questCollection.InsertOneAsync(newQuest);

    public async Task CreateAsync(Questionnaire newQuest)
    {
        newQuest.guid = Guid.NewGuid().ToString();

        await createAsync(newQuest);
    }


    public async Task UpdateAsync(int id, Questionnaire updatedQuest) =>
        await _questCollection.ReplaceOneAsync(x => x.qid==id, updatedQuest);

    public async Task DeleteAsync(int id) => 
        await _questCollection.DeleteOneAsync(x => x.qid==id);
}
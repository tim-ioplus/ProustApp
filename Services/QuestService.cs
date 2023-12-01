using ProustApp.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ProustApp.Services;

public class QuestsService
{
    private readonly IMongoCollection<Questionnaire> _questCollection;

    public QuestsService(IOptions<QuestStoreDatabaseSettings> questStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(questStoreDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(questStoreDatabaseSettings.Value.DatabaseName);
        _questCollection = mongoDatabase.GetCollection<Questionnaire>(questStoreDatabaseSettings.Value.QuestsCollectionName);
        var x = new QuestDataHelper().Get();
        _questCollection.InsertMany(x);
    }

    public async Task<List<Questionnaire>> ListAsync() => 
        await _questCollection.Find(_ => true).ToListAsync();

    public async Task<List<Questionnaire>> ListUnfilledAsync() => 
        await _questCollection.Find(x => string.IsNullOrEmpty(x.ResponseAuthor)).ToListAsync();
    
    public async Task<List<Questionnaire>> ListFilledASync() => 
        await _questCollection.Find(x => !string.IsNullOrEmpty(x.ResponseAuthor)).ToListAsync(); 
    
    public async Task<Questionnaire?> ReadAsync(string id) => 
        await _questCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Questionnaire newQuest) =>
        await _questCollection.InsertOneAsync(newQuest);
    
    public async Task UpdateAsync(string id, Questionnaire updatedQuest) =>
        await _questCollection.ReplaceOneAsync(x => x.Id==id, updatedQuest);

    public async Task DeleteAsync(string id) => 
        await _questCollection.DeleteOneAsync(x => x.Id==id);
}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProustApp.Domain;

/// <summary>
/// Domain Class for Questionnaire Data in Document Format 
/// </summary>
/// <see cref="../Concept/Domain/document.json"/>
public class Questionnaire
{
    /// <summary>
    /// Unique Identifier for Questionnaire
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _objectId { get; set; }
    //
    public int? qid { get; set; }
    //
    public string? guid { get; set; }
    /// <summary>
    /// Who is asking the Questions
    /// </summary>
    public string? Author { get; set; }
    /// <summary>
    /// Whats the Topic of the survey?
    /// </summary>
    public string? Topic { get; set; }
    /// <summary>
    /// Who is answering the Questions
    /// </summary>
    public string? ResponseAuthor { get; set; }
    /// <summary>
    /// Questions and correponding Answers in Key-Value Form
    /// </summary>                
    //public Dictionary<string, string>? Dialogs {get; set;}
    public List<Dialog>? Dialogs {get; set;}

}

public class Dialog
{
    public string? Question  { get; set;}
    public string? Answer { get; set;}

    public Dialog(string q, string a)
    {
        Question = q;
        Answer = a;
    }
}

public class QuestStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string QuestsCollectionName { get; set; } = null!;
}
namespace ProustApp.Domain;

/// <summary>
/// Domain Class for Questionnaire Data in Document Format 
/// </summary>
/// <see cref="../Concept/Domain/document.json"/>
public class Questionnaire
{
    /// <summary>
    /// UNique Identifier for Questionnaire
    /// </summary>
    public int Id { get; set; }
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
    public IDictionary<string, string>? Dialogs {get; set;}
}
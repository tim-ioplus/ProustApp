namespace ProustApp.DomainORM;


/// <summary>
/// Complete Data of a Survey answered by an Author.
/// Combines several Domain Classes for a simpler Front-End View. 
/// </summary>
[Obsolete("Use Non ORM Domain Classes")]
public class quest
{
    public questMetadata? Metadata {get; set;}
    public Survey? Survey {get; set;}
    public List<Dialog>? Dialogs {get;set;}
}

/// <summary>
/// Meta data of a Survey answered by an Author 
/// </summary>
[Obsolete("Use Non ORM Domain Classes")]
public class questMetadata
{
    int id {get; set;}
    string? Author {get; set;}
    int SurveyId { get; set; }
}

/// <summary>
/// A Set of Questions setted up by an Author  
/// </summary>
[Obsolete("Use Non ORM Domain Classes")]
public class Survey 
{
    int Id {get; set;}
    string? Author {get; set;}
    string? Title {get; set;}
    List<Question>? Questions {get;set;}    
}

/// <summary>
/// Association Class for a Question and correponding Answer
/// </summary>
[Obsolete("Use Non ORM Domain Classes")]
public class Dialog
{
    public Question? Question {get; set;}
    public Answer? Answer {get; set;}
}

/// <summary>
/// A Question from a Survey
/// </summary>
[Obsolete("Use Non ORM Domain Classes")]
public class Question
{
    int Id { get; set; }
    int SurveyId { get; set; }
    int Number{get; set;}
    string? Text {get; set;}
}

/// <summary>
/// An answer to a Question from a quest
/// </summary>
[Obsolete("Use Non ORM Domain Classes")]
public class Answer
{
    int Id {get; set;}
    int QuestionId {get; set;}
    int questId {get;set;}
    string? Text {get; set;}
}
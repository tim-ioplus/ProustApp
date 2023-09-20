namespace ProustApp.Domain;


/// <summary>
/// Complete Data of a Survey answered by an Author.
/// Combines several Domain Classes for a simpler Front-End View. 
/// </summary>
public class Questionnaire
{
    public QuestionnaireMetadata? Metadata {get; set;}
    public Survey? Survey {get; set;}
    public List<Dialog>? Dialogs {get;set;}
}

/// <summary>
/// Meta data of a Survey answered by an Author 
/// </summary>
public class QuestionnaireMetadata
{
    int id {get; set;}
    string? Author {get; set;}
    int SurveyId { get; set; }
}

/// <summary>
/// A Set of Questions setted up by an Author  
/// </summary>
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
public class Dialog
{
    public Question? Question {get; set;}
    public Answer? Answer {get; set;}
}

/// <summary>
/// A Question from a Survey
/// </summary>
public class Question
{
    int Id { get; set; }
    int SurveyId { get; set; }
    int Number{get; set;}
    string? Text {get; set;}
}

/// <summary>
/// An answer to a Question from a Questionnaire
/// </summary>
public class Answer
{
    int Id {get; set;}
    int QuestionId {get; set;}
    int QuestionnaireId {get;set;}
    string? Text {get; set;}
}
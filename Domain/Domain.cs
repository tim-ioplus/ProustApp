namespace ProustApp.Domain;
    
public class Questionnaire
{
    int id {get; set;}
    string? Author {get; set;}
}

public class Question
{
    int id { get; set; }
    int QuestionnaireId {get; set;}
    string? Author {get; set;}

    string? Text {get; set;}
}

public class Answer
{
    int id {get; set;}
    string? Author {get; set;}

    string? Text {get; set;}
}


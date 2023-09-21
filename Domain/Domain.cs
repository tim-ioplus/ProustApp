namespace ProustApp.Domain;

[Obsolete("Use Document Class Questionnaire")]
public class Quest 
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string? QuestionAuthor { get; set; }
    public string? QuestionText { get; set; }
    
    public int? AnswerId { get; set; }
    public string? AnswerAuthor { get; set; }
    public string? AnswerText { get; set; }
}
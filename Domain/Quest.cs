namespace ProustApp;

public class Quest 
{
    public int Id = 0;
    public int QuestionId = 0;
    public string QuestionAuthor = "";
    public string QuestionText = "";
    
    public int AnswerId = 0;
    public string AnswerAuthor = "";
    public string AnswerText = "";

    public Quest(){}
    public Quest(int id, 
        int questionId, string questionAuthor, string questionText, 
        int answerId, string answerAuthor, string answerText)
    {
        Id = id;
        QuestionId = questionId;
        QuestionAuthor = questionAuthor;
        QuestionText = questionText;
        AnswerId = answerId;
        AnswerAuthor = answerAuthor;
        AnswerText = answerText;
    }
}























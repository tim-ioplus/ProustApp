namespace ProustApp;

public class Dialog 
{
    int Id;
    int QuestionId;
    string QuestionText;
    int AnswerId;
    string AnswerText;
}
public class Question 
{
    int Id;
    string Author;
    string Text;
}

public class Answer
{
    int Id;
    int QuestionId;
    string Author;
    string Text;
}
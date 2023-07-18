namespace Skateroom.Models;

public class Challenge
{
    public string CorrectAnswer { get; private set; }

    public Challenge(string correctAnswer)
    {
        CorrectAnswer = correctAnswer;
    }

    public bool CheckAnswer(string answer)
    {
        return CorrectAnswer.Equals(answer);
    }
}

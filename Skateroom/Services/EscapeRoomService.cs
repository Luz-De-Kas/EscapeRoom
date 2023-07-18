namespace Skateroom.Services;

public class EscapeRoomService
{
    private int currentChallengeIndex = 0;

    // TODO: Define the correct answer codes for each challenge
    private List<string> challengeAnswers = new()
    {
        "1234",//"Coca", // Challenge 1
        "1234",//"67890", // Challenge 2
        "1234",//"pachacutec", // Challenge 3
        "1234",//"ghijkl", // Challenge 4
        "1234",//"mnopqr", // Challenge 5
        "1234",//"stuvwx"  // Challenge 6
    };

    public bool TryAnswerCurrentChallenge(string answer)
    {
        if (currentChallengeIndex >= challengeAnswers.Count)
        {
            return false;
        }

        if (answer == challengeAnswers[currentChallengeIndex])
        {
            // If the answer is correct, advance to the next challenge
            currentChallengeIndex++;
            return true;
        }
        return false;
    }

    public bool HasMoreChallenges()
    {
        // Check if there are more challenges to solve
        return currentChallengeIndex < challengeAnswers.Count;
    }

    public int GetCurrentChallengeNumberLength()
    {
        // Get the number of digits of the current challenge answer
        return challengeAnswers[currentChallengeIndex].Length;
    }
    public void FinishGame()
    {
        currentChallengeIndex = 0;
    }
}

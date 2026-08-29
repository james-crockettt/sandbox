DisplayMainMenu();
int userAnswer = GetUserAnswer();
int computerAnswer = GetComputerAnswer();
bool gameResult = EvaluateAnswers(userAnswer, computerAnswer);
string userAnswerString = AnswerToString(userAnswer);
string computerAnswerString = AnswerToString(computerAnswer);
WriteResult(gameResult, userAnswerString, computerAnswerString);

void DisplayMainMenu()
{
    Console.Write("Please enter the number corresponding to your answer:\n" +
                    " -> (1) Rock\n" + 
                    " -> (2) Paper\n" +
                    " -> (3) Scissors\n" +
                    ">>> ");
}

int GetUserAnswer()
{
    int userAnswer = int.Parse(Console.ReadLine() ?? "3") - 1;
    while (userAnswer < 0 || userAnswer > 2)
    {
        Console.Write("Inavlid answer, please try again: \n" +
                    ">>> ");
        userAnswer = int.Parse(Console.ReadLine() ?? "3") - 1;  
    }
    return userAnswer;
}

int GetComputerAnswer()
{
    Random computer = new();
    return computer.Next(0, 3);
}

bool EvaluateAnswers(int userAnswer, int computerAnswer)
{
    switch (userAnswer)
    {
        case 0:
            // User answers rock
            if (computerAnswer == 1) {
                return false;
            } else if (computerAnswer == 2)
            {
                return true;
            } else
            {
                throw new ArgumentOutOfRangeException("Answer is out of acceptable range (0-2 inclusive).", nameof(computerAnswer));
            }
        case 1:
            // User answers paper
            if (computerAnswer == 0) {
                return true;
            } else if (computerAnswer == 2)
            {
                return false;
            } else
            {
                throw new ArgumentOutOfRangeException("Answer is out of acceptable range (0-2 inclusive).", nameof(computerAnswer));                
            }
        case 2:
            // User answers scissors
            if (computerAnswer == 0) {
                return false;
            } else if (computerAnswer == 1)
            {
                return true;
            } else
            {
                throw new ArgumentOutOfRangeException("Answer is out of acceptable range (0-2 inclusive).", nameof(computerAnswer));
            };
        default:
            /*  This block should only run if a user or computer
                somehow produced an out of range answer. Thus, this will
                throw an exception. */
            if (userAnswer < 0 || userAnswer > 2)
            {
                throw new ArgumentOutOfRangeException("Answer is out of acceptable range (0-2 inclusive).", nameof(userAnswer));
            } else if (computerAnswer < 0 || computerAnswer > 2) {
                throw new ArgumentOutOfRangeException("Answer is out of acceptable range (0-2 inclusive).", nameof(computerAnswer));
            } else
            {
                throw new Exception("An unexpected error occured.");
            }
    }
}

string AnswerToString(int answer)
{
    switch (answer)
    {
        case 0:
            return "rock";
        case 1:
            return "paper";
        case 2:
            return "scissors";
        default:
            throw new Exception("An unexpected error occured.");
    }
}

void WriteResult(bool gameResult, string userAnswerString, string computerAnswerString)
{
    Console.WriteLine($"You answered: {userAnswerString}\n" +
                        $"The computer answered: {computerAnswerString}");
    if (gameResult is true)
    {
        Console.WriteLine($"You won, {userAnswerString} beats {computerAnswerString}");
    } else if (gameResult is false)
    {
        Console.WriteLine($"You lost, {computerAnswerString} beats {userAnswerString} :(");
    } else
    {
        throw new Exception("An unexpected error occured.");
    }
}
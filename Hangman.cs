List<string> words = new List<string>() { "word", "hello", "before", "walking", "handsome", "excellent", "congratulations", "deoxyribonucleotide", };

Random random = new Random();

string code = words[random.Next(0, words.Count)];

int maxLive = 7;
bool headCheck = false;
bool bodyCheck = false;
bool rightArmCheck = false;
bool leftArmCheck = false;
bool rightLegCheck = false;
bool leftLegCheck = false;
bool faceCheck = false;
bool gameOver = false;
bool win = false;

List<char> guessedLetters = new List<char>();

while (maxLive > 0 && !win)
{
    foreach (char c in code)
    {
        if (guessedLetters.Contains(c))
        {
            Console.Write(c);
        }
        else
        {
            Console.Write("_");
        }
    }
    Console.WriteLine("\n\nPlease guess a letter!\n");
    char guess = char.Parse(Console.ReadLine());

    if (code.Contains(guess) && !guessedLetters.Contains(guess))
    {
        Console.WriteLine("Correct!");
        Console.WriteLine("\n\n");
    }
    else
    {
        Console.WriteLine("Incorrect!");
        Console.WriteLine("\n\n");
        maxLive--;
    }

    guessedLetters.Add(guess);

    bool codeComplete = true;

    foreach (char c in code)
    {
        if (!guessedLetters.Contains(c))
        {
            codeComplete = false;
        }
    }

    win = codeComplete;

    switch (maxLive)
    {
        case 6:
            headCheck = true;
            break;
        case 5:
            bodyCheck = true;
            break;
        case 4:
            rightArmCheck = true;
            break;
        case 3:
            leftArmCheck = true;
            break;
        case 2:
            rightLegCheck = true;
            break;
        case 1:
            leftLegCheck = true;
            break;
        case 0:
            faceCheck = true;
            gameOver = true;
            break;
    }
    Gallow();
    Head(headCheck, faceCheck);
    Body(bodyCheck, rightArmCheck, leftArmCheck);
    Lower(rightLegCheck, leftLegCheck);
    GameOver(gameOver);

}
if (win)
{
    Console.WriteLine("You won!");
}
else
{
    Console.WriteLine("You lose!");
}



static void Gallow()
{

    Console.Write(new string(' ', 5));
    for (int i = 0; i < 5; i++)
    {
        Console.Write("*" + "  ");
    }
    Console.WriteLine();
    for (int i = 0; i < 3; i++)
    {
        Console.Write(new string(' ', 5) + "*" + new string(' ', 11) + "*");
        Console.WriteLine();
    }

}

static void Head(bool headCheck, bool faceCheck)
{
    if (headCheck && !faceCheck)
    {
        Console.WriteLine("    * *          *");
        Console.WriteLine("  *     *        *");
        Console.WriteLine("  *     *        *");
        Console.WriteLine("    * *          *");
    }
    else if (headCheck && faceCheck)
    {
        Console.WriteLine("    * *          *");
        Console.WriteLine("  * x x *        *");
        Console.WriteLine("  * --- *        *");
        Console.WriteLine("    * *          *");
    }
    else
    {
        for (int i = 0; i < 4; i++)
        {
            Console.Write(new string(' ', 17) + "*");
            Console.WriteLine();
        }
    }
}

static void Body(bool bodyCheck, bool rightArmCheck, bool leftArmCheck)
{
    if (bodyCheck && !rightArmCheck && !leftArmCheck)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("     *           *");
        }
    }
    else if (bodyCheck && rightArmCheck && !leftArmCheck)
    {
        Console.WriteLine("     *           *");
        Console.WriteLine("   * *           *");
        Console.WriteLine("  *  *           *");
        Console.WriteLine(" *   *           *");
        Console.WriteLine("     *           *");
    }
    else if (bodyCheck && rightArmCheck && leftArmCheck)
    {
        Console.WriteLine("     *           *");
        Console.WriteLine("   * * *         *");
        Console.WriteLine("  *  *  *        *");
        Console.WriteLine(" *   *   *       *");
        Console.WriteLine("     *           *");
    }
    else
    {
        for (int i = 0; i < 4; i++)
        {
            Console.Write(new string(' ', 17) + "*");
            Console.WriteLine();
        }
    }
}

static void Lower(bool rightLegCheck, bool leftLegCheck)
{
    if (rightLegCheck && !leftLegCheck)
    {
        Console.WriteLine("    *            *");
        Console.WriteLine("   *             *");
        Console.WriteLine("  *              *");
    }
    else if (rightLegCheck && leftLegCheck)
    {
        Console.WriteLine("    * *          *");
        Console.WriteLine("   *   *         *");
        Console.WriteLine("  *     *        *");
    }
    else
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write(new string(' ', 17) + "*");
            Console.WriteLine();
        }
    }
    Console.WriteLine(new string(' ', 17) + "*");
    Console.WriteLine(new string(' ', 5) + "* * * * * * * * * * * * *\n");
}

static void GameOver(bool gameOver)
{
    if (gameOver)
    {
        Console.WriteLine("    * *---------------------* *");
        Console.WriteLine("    * |      GAME OVER      | *");
        Console.WriteLine("    * *---------------------* *");
        Console.WriteLine(new string(' ', 5) + "* * * * * * * * * * * * *");
    }
}

/*
    *  *  *  *  *
    *           *
    *           *
    *           *
   * *          *
 * x x *        *
 * --- *        *
   * *          *
    *           *
  * * *         *
 *  *  *        *
*   *   *       *
    *           *
   * *          *
  *   *         *
 *     *        *
                *
         * * * * * * * *
*/
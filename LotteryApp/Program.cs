// Lottery Drawing Application
// Takes a list of names as command line arguments and draws a random winner

if (args.Length == 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Error: No names provided!");
    Console.ResetColor();
    Console.WriteLine();
    Console.WriteLine("Usage: LotteryApp <name1> <name2> <name3> ...");
    Console.WriteLine("Example: LotteryApp Alice Bob Charlie Diana");
    return 1;
}

// Display header
Console.Clear();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("╔══════════════════════════════════════════════════╗");
Console.WriteLine("║          🎰 LOTTERY DRAWING APP 🎰               ║");
Console.WriteLine("╚══════════════════════════════════════════════════╝");
Console.ResetColor();
Console.WriteLine();

// Display participants
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"Participants ({args.Length}):");
Console.ResetColor();
for (int i = 0; i < args.Length; i++)
{
    Console.WriteLine($"  {i + 1}. {args[i]}");
}
Console.WriteLine();

// Wait for user to start
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Press ENTER to start the drawing...");
Console.ResetColor();
Console.ReadLine();

// Animation: Cycle through names with decreasing speed
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("🎲 Drawing winner...");
Console.ResetColor();
Console.WriteLine();

// Random selection
Random random = new Random();
int winnerIndex = random.Next(args.Length);

int totalSpins = 40 - (40 % args.Length) + winnerIndex + 1;

int F(double x)
{
    // Upside-down bell curve: vertex at totalSpins/2, F(0) = F(totalSpins) = 500
    double h = totalSpins / 2.0; // x-coordinate of vertex (turning point)
    double k = 50.0; // y-coordinate of vertex (minimum delay for fastest spin)
    double a = (500.0 - k) / (h * h); // coefficient to ensure F(0) = F(totalSpins) = 500

    var ret = a * (x - h) * (x - h) + k;
    return (int)ret;
}

// Animate the spinning
int currentIndex = 0;
for (int spin = 0; spin < totalSpins; spin++)
{
    // Clear the current line
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.Write(new string(' ', Console.WindowWidth - 1));
    Console.SetCursorPosition(0, Console.CursorTop);

    // Display current name with fancy formatting
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(">>> ");
    Console.ForegroundColor = ConsoleColor.White;
    for (int i = 0; i < args.Length; i++)
    {
        if (currentIndex == i)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        Console.Write(args[i].PadRight(15));
        Console.ForegroundColor = ConsoleColor.White;
    }

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(" <<<");
    Console.ResetColor();

    Thread.Sleep(F(spin));

    currentIndex = (currentIndex + 1) % args.Length;
}


// Dramatic pause
Thread.Sleep(500);
Console.SetCursorPosition(0, Console.CursorTop);
Console.Write(new string(' ', Console.WindowWidth - 1));
Console.SetCursorPosition(0, Console.CursorTop);

// Display winner with celebration
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("🎉🎉🎉 WINNER 🎉🎉🎉");
Console.ResetColor();
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("╔══════════════════════════════════════════════════╗");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("║  🏆 ");
Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.DarkGreen;
Console.Write($" {args[winnerIndex].ToUpper().PadRight(38)} ");
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(" 🏆  ║");
Console.WriteLine("╚══════════════════════════════════════════════════╝");
Console.ResetColor();
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Congratulations! 🎊");
Console.ResetColor();

return 0;

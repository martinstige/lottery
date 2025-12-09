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
Console.WriteLine("╔════════════════════════════════════════════════╗");
Console.WriteLine("║        🎰 LOTTERY DRAWING APP 🎰              ║");
Console.WriteLine("╔════════════════════════════════════════════════╗");
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

int totalSpins = 40;
int[] delays = new int[totalSpins];

// Create acceleration pattern - start slow, speed up, then slow down at the end
for (int i = 0; i < totalSpins; i++)
{
    if (i < 10)
    {
        // Start slow
        delays[i] = 200 - (i * 10);
    }
    else if (i < 30)
    {
        // Fast middle section
        delays[i] = 50;
    }
    else
    {
        // Slow down at the end for dramatic effect
        delays[i] = 50 + ((i - 29) * 30);
    }
}

// Random selection
Random random = new Random();
int winnerIndex = random.Next(args.Length);

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
    Console.Write(args[currentIndex].PadRight(30));
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(" <<<");
    Console.ResetColor();
    
    Thread.Sleep(delays[spin]);
    
    currentIndex = (currentIndex + 1) % args.Length;
}

// Final reveal - ensure we land on the winner
Console.SetCursorPosition(0, Console.CursorTop);
Console.Write(new string(' ', Console.WindowWidth - 1));
Console.SetCursorPosition(0, Console.CursorTop);

// Dramatic pause
Thread.Sleep(500);

// Display winner with celebration
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("🎉🎉🎉 WINNER 🎉🎉🎉");
Console.ResetColor();
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("╔════════════════════════════════════════════════╗");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.Write("║  🏆 ");
Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.DarkGreen;
Console.Write($" {args[winnerIndex].ToUpper().PadRight(38)} ");
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine(" 🏆  ║");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("╚════════════════════════════════════════════════╝");
Console.ResetColor();
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Congratulations! 🎊");
Console.ResetColor();

return 0;

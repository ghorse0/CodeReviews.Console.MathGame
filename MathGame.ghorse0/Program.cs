using MathGame;
string choice = "";

GameService gameService = new GameService();



while ( !(choice.ToUpper().Equals("Q")))
{
	Console.Clear();
	Console.WriteLine("What game would you like to play? Choose from the options below:");
	Console.WriteLine("V. View Previous Games");
	Console.WriteLine("A. Addition\nS. Subtraction\nM. Multiplication\nD. Division\nQ. Quit the program.");
	choice = Console.ReadLine();
	if (string.IsNullOrEmpty(choice))
	{
		Console.WriteLine("Invalid input. Please try again.");
		return;
	}

	switch (choice.ToUpper())
	{
		case "V":
			gameService.ViewPreviousGames();
			break;
		case "A":
			gameService.GameLoop('A');
			break;
		case "S":
			gameService.GameLoop('S');
			break;
		case "M":
			gameService.GameLoop('M');
			break;
		case "D":
			gameService.GameLoop('D');
			break;
		case "Q":
			break;
		default:
			Console.WriteLine("Invalid choice. Please try again.");
			break;
	}

}

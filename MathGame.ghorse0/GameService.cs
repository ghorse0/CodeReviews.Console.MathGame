using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
	public class GameService
	{

		public GameService() { }

		static List<GameHistory> gameHistories = new List<GameHistory>();
		public void ViewPreviousGames()
		{
			Console.Clear();
			if (gameHistories.Count == 0)
			{
				Console.WriteLine("No previous games found.");
				Console.WriteLine("Press any key to return to the main menu.");
				Console.ReadKey(true);
				return;
			}

			Console.WriteLine("Previous Games:");
			foreach (var game in gameHistories)
			{
				Console.Write($"{game.gameDate}: ");
				switch(game.operation)
				{
					case 'A':
						Console.Write("Addition");
						break;
					case 'S':
						Console.Write("Subtraction");
						break;
					case 'M':
						Console.Write("Multiplication");
						break;
					case 'D':
						Console.Write("Division");
						break;
					default:
						Console.Write("Unknown Operation");
						break;
				}
				Console.WriteLine($", Score: {game.score}");
			}
			Console.WriteLine("Press any key to return to the main menu.");
			Console.ReadKey(true);
		}

		public void GameLoop(char operation)
		{
			int score = 0;
			Console.Clear();
			for (int i = 0; i < 5; i++)
			{
				bool result = GameRound(operation);
				if (result) score++;
				Console.WriteLine("Press any key for next question...");
				Console.ReadKey(true);
				Console.Clear();
			}
			gameHistories.Add(new GameHistory { gameDate = DateTime.Now, operation = operation, score = score });
			Console.WriteLine($"Game over! Your score is {score}.");
			Console.WriteLine("Press any key to return to the main menu.");
			Console.ReadKey(true);
		}

		public bool GameRound(char operation)
		{
			int correctAnswer = 0;
			Random random = new Random();
			int number1 = random.Next(1, 10);
			int number2 = random.Next(1, 10);
			char opSymbol = operation 
			switch
			{
				'A' => '+',
				'S' => '-',
				'M' => '*',
				'D' => '/',
				_ => '?'
			}; //AI suggestion

			switch (operation)
			{
				case 'A':
					correctAnswer = number1 + number2;
					break;
				case 'S':
					correctAnswer = number1 - number2;
					break;
				case 'M':
					correctAnswer = number1 * number2;
					break;
				case 'D':
					while(number1 % number2 != 0)
					{
						number1 = random.Next(1, 10);
						number2 = random.Next(1, 10);
					}
					correctAnswer = number1 / number2;
					break;
				default:
					Console.WriteLine("Invalid operation.");
					return false;
			}

			Console.WriteLine($"What is {number1} {opSymbol} {number2}?");
			string userInput = Console.ReadLine();
			if (int.TryParse(userInput, out int userAnswer))
			{
				if (userAnswer == correctAnswer)
				{
					Console.WriteLine("Correct!");
					return true;
				}
				else
				{
					Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}.");
					return false;
				}
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter a number.");
				return false;
			}



		}
	}
}

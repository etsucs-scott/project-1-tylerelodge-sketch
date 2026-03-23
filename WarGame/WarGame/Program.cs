using System;
using System.Linq;
using WarGame.Core;

class Program
{
    static void Main(string[] args)
    {
        int playerCount = GetPlayerCount(args);

        var players = Enumerable.Range(1, playerCount)
                                .Select(i => $"Player {i}")
                                .ToList();

        var game = new WarGame.Core.WarGame(players);

        int round = 0;
        const int MAX_ROUNDS = 10000;

        while (round < MAX_ROUNDS)
        {
            round++;

            var result = game.PlaySingleRound();

            if (result.FinalWinner != null)
            {
                Console.WriteLine($"\n {result.FinalWinner} wins the game!");
                return;
            }

            PrintRound(round, result);
        }

        Console.WriteLine("\n Round limit reached!");

        //  Decide winner after limit
        var winner = game
            .GetType()
            .GetField("_playerHands", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.GetValue(game) as PlayerHands;

        if (winner != null)
        {
            var max = winner.Hands.Max(h => h.Value.Count);
            var winners = winner.Hands
                .Where(h => h.Value.Count == max)
                .Select(h => h.Key)
                .ToList();

            Console.WriteLine(winners.Count == 1
                ? $" Winner by cards: {winners[0]}"
                : " Game is a draw");
        }
    }

    static int GetPlayerCount(string[] args)
    {
        if (args.Length > 0 && int.TryParse(args[0], out int count))
        {
            if (count >= 2 && count <= 4)
                return count;
        }

        Console.Write("Enter number of players (2-4): ");
        return int.Parse(Console.ReadLine()!);
    }

    static void PrintRound(int round, RoundResult result)
    {
        Console.WriteLine("Press Enter for next round...");
        Console.ReadLine();

        Console.WriteLine($"\n--- Round {round} ---");

        foreach (var play in result.PlayedCards)
            Console.WriteLine($"{play.Key} played {play.Value}");

        if (result.IsTie)
            Console.WriteLine(" Tie! Tiebreaker...");
        else
            Console.WriteLine($" Winner: {result.RoundWinners[0]}");

        Console.WriteLine("Card Counts:");
        foreach (var c in result.CardCounts)
            Console.WriteLine($"{c.Key}: {c.Value}");
    }
}
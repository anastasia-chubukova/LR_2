using System;

namespace LR_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameAccount firstPlayer = new OnlyLose("Andrew");
            GameAccount secondPlayer = new DoubleRate("Den");
            ReturnGame getgame = new ReturnGame();
            var game = getgame.Reverse();

            game.play(firstPlayer, secondPlayer, 1, 2);

            firstPlayer.GetStats();
            secondPlayer.GetStats();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Game N1");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(firstPlayer.GetStats());
            Console.WriteLine(secondPlayer.GetStats());

            game.play(secondPlayer, firstPlayer, 3, 2);
            game.play(secondPlayer, firstPlayer, 10, 6);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Statistics of each player");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(firstPlayer.GetStats());
            Console.WriteLine(secondPlayer.GetStats());
        }
    }
}
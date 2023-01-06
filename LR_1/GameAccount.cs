using System.Collections.Generic;
using System;
using System.Text;

namespace LR_2
{
    public class GameAccount
    {
        public string UserName { get; set; }
        public int CurrentRating
        {
            get
            {
                int Rating = 20;
                foreach (var game in allGames)
                {
                    Rating += game.RatingGame;
                }

                return Rating;
            }
        }
        public int GamesCount { get; set; }

        public List<GameResult> allGames = new List<GameResult>();

        public GameAccount(string name)
        {
            UserName = name;
        }

        public virtual void WinGame(BaseGame game)
        {
            if (game.history[^1].rate1 <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game), "Rating can't be < 1");
            }

            this.GamesCount++;
            GameResult Game = new GameResult(game.history[^1].loser.UserName, 1, game.history[^1].rate1, DateTime.Now, GamesCount);
            allGames.Add(Game);


        }
        public virtual void LoseGame(BaseGame game)
        {
            if (game.history[^1].rate2 <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game), "Rating can't be < 1");
            }
            if (CurrentRating - game.history[^1].rate2 <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game), "Rating can't be > rating of the player");
            }
            this.GamesCount++;
            GameResult Game = new GameResult(game.history[^1].winner.UserName, 0, -game.history[^1].rate2, DateTime.Now, GamesCount);
            allGames.Add(Game);

        }

        public string GetStats()
        {
            var history = new System.Text.StringBuilder();

            int currentRating = 20;
            history.AppendLine("Opponent name:\tGame rating:\tResult:\t\tGame ID:\tGame Time:");
            foreach (var game in allGames)
            {
                currentRating += game.RatingGame;
                history.AppendLine($"{game.Opponetname}\t\t{currentRating}\t\t{game.Result}\t\t{game.ID}\t\t{DateTime.Now}");
            }

            return history.ToString();

        }
    }

    public class DoubleRate : GameAccount
    {
        public DoubleRate(string name) : base(name)
        {
            UserName = name;
        }
        
        public override void WinGame(BaseGame game)
        {
            if (game.history[^1].rate1 <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game), "Rating can't be < 1");
            }

            this.GamesCount++;
            GameResult Game = new GameResult(game.history[^1].loser.UserName, 1, 2*game.history[^1].rate1, DateTime.Now, GamesCount);
            allGames.Add(Game);


        }
        
        public override void LoseGame(BaseGame game)
        {
            if (game.history[^1].rate2 <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game), "Rating can't be < 1");
            }
            if (CurrentRating - game.history[^1].rate2 <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game), "Rating can't be > rating of the player");
            }
            this.GamesCount++;
            GameResult Game = new GameResult(game.history[^1].winner.UserName, 0, -2 * game.history[^1].rate2, DateTime.Now, GamesCount);
            allGames.Add(Game);

        }
    }
    
    public class OnlyLose : GameAccount
    {
        public OnlyLose(string name) : base(name)
        {
            UserName = name;
        }
        
        public override void WinGame(BaseGame game)
        {
            if (game.history[^1].rate1 <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game), "Rating can't be < 1");
            }

            this.GamesCount++;
            GameResult Game = new GameResult(game.history[^1].loser.UserName, 1, 0, DateTime.Now, GamesCount);
            allGames.Add(Game);


        }
    }
    
    public class OnlyWin : GameAccount
    {
        public OnlyWin(string name) : base(name)
        {
            UserName = name;
        }

        public override void LoseGame(BaseGame game)
        {
            if (game.history[^1].rate2 <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game), "Rating can't be < 1");
            }
            if (CurrentRating - game.history[^1].rate2 <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game), "Rating can't be > rating of the player");
            }
            this.GamesCount++;
            GameResult Game = new GameResult(game.history[^1].winner.UserName, 0, 0, DateTime.Now, GamesCount);
            allGames.Add(Game);

        }
    }
}
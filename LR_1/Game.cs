using System.ComponentModel.DataAnnotations;

namespace LR_2;

public class GameHistory
{
    public GameAccount winner;
    public GameAccount loser;
    public int rate1;
    public int rate2;

    public GameHistory(GameAccount winner, GameAccount loser, int rate1, int rate2)
    {
        this.winner = winner;
        this.loser = loser;
        this.rate1 = rate1;
        this.rate2 = rate2;
    }
}

public abstract class BaseGame
{
    public List<GameHistory> history = new List<GameHistory>();
    public abstract void play(GameAccount winner, GameAccount loser, int rate1, int rate2);
}

public class Game : BaseGame
{
    public override void play(GameAccount winner, GameAccount loser, int rate1, int rate2)
    {
        history.Add(new GameHistory(winner, loser, rate1, rate2));
        winner.WinGame(this);
        loser.LoseGame(this);
    }
}

public class NegativeRate : BaseGame
{
    public override void play(GameAccount winner, GameAccount loser, int rate1, int rate2)
    {
        history.Add(new GameHistory(winner, loser, -rate1, -rate2));
        winner.WinGame(this);
        loser.LoseGame(this);
    }
}

public class Reverse : BaseGame
{
    public override void play(GameAccount winner, GameAccount loser, int rate1, int rate2)
    {
        history.Add(new GameHistory(winner, loser, rate2, rate1));
        winner.WinGame(this);
        loser.LoseGame(this);
    }
}
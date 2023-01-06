namespace LR_2;

public class ReturnGame
{
    public BaseGame Game()
    {
        return new Game();
    }
    
    public BaseGame NegativeRate()
    {
        return new NegativeRate();
    }
    public BaseGame Reverse()
    {
        return new Reverse();
    }
}
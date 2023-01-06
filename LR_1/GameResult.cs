namespace LR_2
{
    public class GameResult
    {
        public string Opponetname { get; }
        public int Result { get; }
        public int RatingGame { get; }
        public DateTime Date { get; }
        public int ID { get; }
        public GameResult(string name, int result, int rating, DateTime date, int index)
        {
            Opponetname = name;
            Result = result;
            RatingGame = rating;
            Date = date;
            ID = index;
        }
    }
}
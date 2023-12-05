namespace OneBackComboTrainingWeb;

public class TennisGame
{
    private string _firstPlayerName;
    private Dictionary<int, string> _scoreDic;
    private string _secondPlayerName;

    public TennisGame(string firstPlayerName, string secondPlayerName)
    {
        _secondPlayerName = secondPlayerName;
        _firstPlayerName = firstPlayerName;
        _scoreDic = new Dictionary<int, string>()
        {
            { 0, "love" },
            { 1, "fifteen" },
            { 2, "thirty" },
            { 3, "forty" }
        };
    }

    public string Score(int firstPlayerScore, int secondPlayerScore)
    {
        if (firstPlayerScore == secondPlayerScore)
        {
            if (firstPlayerScore >= 3)
                return "deuce";

            return $"{_scoreDic[firstPlayerScore]} all";
        }
        else
        {
            var showPlayer = string.Empty;
            if (firstPlayerScore > secondPlayerScore)
            {
                showPlayer = _firstPlayerName;
            }
            else
            {
                showPlayer = _secondPlayerName;
            }

            if (firstPlayerScore >= 3 && secondPlayerScore >= 3)
            {
                if (Math.Abs(firstPlayerScore - secondPlayerScore) == 1)
                {
                    return $"{showPlayer} adv";
                }

                return $"{showPlayer} win";
            }
            else
            {
                if (Math.Max(firstPlayerScore, secondPlayerScore) > 3)
                {
                    return $"{showPlayer} win";
                }
            }

            return $"{_scoreDic[firstPlayerScore]} {_scoreDic[secondPlayerScore]}";
        }

    }
}
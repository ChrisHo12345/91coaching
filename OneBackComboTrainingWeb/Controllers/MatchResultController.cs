namespace OneBackComboTrainingWeb.Controllers;

public class MatchResultController
{
    private string _matchResult = "0:0(First Half)";
    private string _matchResultRepo;
    private string _previousMatchResult = "";
    private int _homeScore;
    private int _awayScore;
    private string _period = "First Half";
    private Dictionary<string, string> _matchResultLookup = new Dictionary<string, string>
    {
        {"homeGoal","H"},
        {"awayGoal","A"},
        {"periodChange",";"},
    };

    public string GetMatchResult()
    {
        return _matchResult;
    }

    public void ReceivedEvent(string soccerEvent)
    {
        _matchResultRepo = $"{_previousMatchResult}{_matchResultLookup[soccerEvent]}";

        List<char> lsMatchResultChars = _matchResultRepo.ToCharArray().ToList();
        _period = _matchResultRepo.Contains(";") ? "Second Half" : "First Half";
        _homeScore = lsMatchResultChars.Count(x => x == 'H');
        _awayScore = lsMatchResultChars.Count(x => x == 'A');

        _matchResult = $"{_homeScore}:{_awayScore}({_period})";
    }

    public void GetMatchResultRepo(string matchResultRepo)
    {
        _previousMatchResult = matchResultRepo;

    }
}
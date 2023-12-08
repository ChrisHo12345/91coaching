namespace OneBackComboTrainingWeb.Controllers;

public class MatchResultController
{
    private string _matchResult = "0:0(First Half)";
    private string _matchResultRepo = "";
    private string _previousMatchResult = "";
    private int _homeScore;
    private int _awayScore;
    private string _period = "First Half";
    private readonly Dictionary<string, string> _matchResultLookup = new()
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
        _matchResult = MatchResultParser(_matchResultRepo);
    }

    private string MatchResultParser(string matchResultRepo)
    {
        List<char> lsMatchResultChars = matchResultRepo.ToCharArray().ToList();
        _period = matchResultRepo.Contains(";") ? "Second Half" : "First Half";
        _homeScore = lsMatchResultChars.Count(x => x == 'H');
        _awayScore = lsMatchResultChars.Count(x => x == 'A');
        return $"{_homeScore}:{_awayScore}({_period})";
    }

    public void GetMatchResultRepo(string matchResultRepo)
    {
        _previousMatchResult = matchResultRepo;
    }
}
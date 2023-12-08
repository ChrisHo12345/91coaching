using NSubstitute.Routing.Handlers;
using OneBackComboTrainingWeb.Controllers;

namespace OneBackTests;

[TestFixture]
public class MatchResultTests
{
    private MatchResultController _matchResult;

    [SetUp]
    public void SetUp()
    {
        _matchResult = new MatchResultController();
    }
    [Test]
    public void initial_match_result()
    {
        ScoreShouldBe("0:0(First Half)");
    }
    [Test]
    public void home_goal_when_0_0_first_half()
    {
        GivenPreviousMatchResult("");
        WhenReceivedEvent("homeGoal");
        ScoreShouldBe("1:0(First Half)");
    }
    [Test]
    public void home_goal_when_1_0_first_half()
    {
        GivenPreviousMatchResult("H");
        WhenReceivedEvent("homeGoal");
        ScoreShouldBe("2:0(First Half)");
    }
    [Test]
    public void away_goal_when_1_0_first_half()
    {
        GivenPreviousMatchResult("H");
        WhenReceivedEvent("awayGoal");
        ScoreShouldBe("1:1(First Half)");
    }
    [Test]
    public void period_change_when_1_0_first_half()
    {
        GivenPreviousMatchResult("H");
        WhenReceivedEvent("periodChange");
        ScoreShouldBe("1:0(Second Half)");
    }
    [Test]
    public void period_change_when_0_0_first_half()
    {
        GivenPreviousMatchResult("");
        WhenReceivedEvent("periodChange");
        ScoreShouldBe("0:0(Second Half)");
    }
    [Test]
    public void home_goal_when_0_0_second_half()
    {
        GivenPreviousMatchResult(";");
        WhenReceivedEvent("homeGoal");
        ScoreShouldBe("1:0(Second Half)");
    }
    [Test]
    public void away_goal_when_frist_half_0_0_second_half_1_0()
    {
        GivenPreviousMatchResult(";H");
        WhenReceivedEvent("awayGoal");
        ScoreShouldBe("1:1(Second Half)");
    }
    [Test]
    public void away_goal_when_frist_half_1_0_second_half_1_0()
    {
        GivenPreviousMatchResult("H;");
        WhenReceivedEvent("awayGoal");
        ScoreShouldBe("1:1(Second Half)");
    }

    private void GivenPreviousMatchResult(string matchResultRepo)
    {
        _matchResult.GetMatchResultRepo(matchResultRepo);
    }

    private void WhenReceivedEvent(string soccerEvent)
    {
        _matchResult.ReceivedEvent(soccerEvent);
    }

    private void ScoreShouldBe(string expected)
    {
        Assert.That(_matchResult.GetMatchResult(),Is.EqualTo(expected));
    }
}
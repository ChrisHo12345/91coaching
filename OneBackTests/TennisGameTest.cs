using FluentAssertions;
using OneBackComboTrainingWeb;

namespace OneBackTests;
[TestFixture]
public class TennisGameTest
{
    [SetUp]
    public void SetUp()
    {
        
    }

    [Test]
    public void first_win_when_score_4_1()
    {
        var tennisGame = new TennisGame("Eva","Eric");
        var score = tennisGame.Score(4, 1);
        score.Should().Be("Eva win");
    }
    [Test]
    public void second_win_when_score_1_4()
    {
        var tennisGame = new TennisGame("Eva","Eric");
        var score = tennisGame.Score(1, 4);
        score.Should().Be("Eric win");
    }

    [Test] 
    public void deuce_win_when_score_4_4()
    {
        var tennisGame = new TennisGame("Eva", "Eric");
        var score = tennisGame.Score(4, 4);
        score.Should().Be("deuce");
    }

}
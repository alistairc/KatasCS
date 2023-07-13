using FluentAssertions;

namespace Katas.AssertionsCompared;

[Explicit("these tests are setup to deliberately fail")]
class DemoAssertionFailureDifferences
{
    [Test]
    public void NUnit_AssertThat_String()
    {
        var actual = "the actual result";
        var expected = "the expected result";
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Shouldly_ShouldBe_String()
    {
        var actual = "the actual result";
        var expected = "the expected result";
        
        actual.ShouldBe(expected);
    }

    [Test]
    public void FluentAssertions_Should_Equal_String()
    {
        var actual = "the actual result";
        var expected = "the expected result";

        actual.Should().Be(expected);
    }

    [Test]
    public void FluentAssertions_Expressions()
    {
        (1 + 3).Should().Be(5);
    } 
    
    //Type inferences
}
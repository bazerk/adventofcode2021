using AdventOfCode.day3;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day3Tests {
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day3/example.txt");
        Assert.AreEqual(198, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day3/example.txt");
        Assert.AreEqual(230, result);
    }
}
using NUnit.Framework;
using AdventOfCode.day7;

namespace AdventOfCodeTests; 

public class Day7Tests {
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day7/example.txt");
        Assert.AreEqual(37, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day7/example.txt");
        Assert.AreEqual(168, result);
    }
}
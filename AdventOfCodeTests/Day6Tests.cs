using AdventOfCode.day6;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day6Tests {
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day6/example.txt");
        Assert.AreEqual(5934, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day6/example.txt");
        Assert.AreEqual(26984457539, result);
    }
}
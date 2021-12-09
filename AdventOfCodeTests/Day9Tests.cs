using AdventOfCode.day9;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day9Tests {
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day9/example.txt");
        Assert.AreEqual(15, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day9/example.txt");
        Assert.AreEqual(1134, result);
    }
}
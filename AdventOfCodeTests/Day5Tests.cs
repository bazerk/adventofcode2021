using AdventOfCode.day5;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day5Tests {
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day5/example.txt");
        Assert.AreEqual(5, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day5/example.txt");
        Assert.AreEqual(12, result);
    }
}
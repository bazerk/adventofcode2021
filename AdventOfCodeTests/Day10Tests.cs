using AdventOfCode.day10;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day10Tests {

    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day10/example.txt");
        Assert.AreEqual(26397, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day10/example.txt");
        Assert.AreEqual(288957, result);
    }
}
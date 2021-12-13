using AdventOfCode.day12;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day12Tests {
    
    [Test]
    public void SmallInputStar1Test() {
        var result = Solver.SolveStar1("day12/small.txt");
        Assert.AreEqual(10, result);
    }
    
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day12/example.txt");
        Assert.AreEqual(226, result);
    }
    
    [Test]
    public void SmallInputStar2Test() {
        var result = Solver.SolveStar2("day12/small.txt");
        Assert.AreEqual(36, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day12/example.txt");
        Assert.AreEqual(3509, result);
    }
}
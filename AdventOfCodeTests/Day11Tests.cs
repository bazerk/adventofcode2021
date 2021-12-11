using AdventOfCode.day11;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day11Tests {

    [Test]
    public void BasicStar1Test() {
        var result = Solver.SolveStar1("day11/basic.txt", 1);
        Assert.AreEqual(9, result);        
    }
    
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day11/example.txt", 10);
        Assert.AreEqual(204, result);
        
        result = Solver.SolveStar1("day11/example.txt");
        Assert.AreEqual(1656, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day11/example.txt");
        Assert.AreEqual(195, result);
    }
}
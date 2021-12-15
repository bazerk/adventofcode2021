using AdventOfCode.day14;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day14Tests {
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day14/example.txt");
        Assert.AreEqual(1588, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day14/example.txt");
        Assert.AreEqual(2188189693529, result);
    }
}
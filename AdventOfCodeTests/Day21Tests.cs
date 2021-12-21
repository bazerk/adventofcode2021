using AdventOfCode.day21;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day21Tests {
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day21/example.txt");
        Assert.AreEqual(739785, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day21/example.txt");
        Assert.AreEqual(444356092776315, result);
    }
}
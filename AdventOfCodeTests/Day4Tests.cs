using AdventOfCode.day4;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day4Tests {
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day4/example.txt");
        Assert.AreEqual(4512, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day4/example.txt");
        Assert.AreEqual(1924, result);
    }
}
using AdventOfCode.day13;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day13Tests {
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day13/example.txt");
        Assert.AreEqual(17, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day13/example.txt");
        var expected =
            "#####\n" +
            "#...#\n" +
            "#...#\n" +
            "#...#\n" +
            "#####\n" +
            ".....\n" +
            ".....\n";
        Assert.AreEqual(expected, result);
    }
}
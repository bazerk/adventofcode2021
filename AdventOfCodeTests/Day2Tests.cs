using NUnit.Framework;
using AdventOfCode.day2;

namespace AdventOfCodeTests;

public class Day2Tests {

    [Test]
    public void ExampleInputTest() {
        var result = Solver.SolveStar1("day2/example.txt");
        Assert.AreEqual(150, result);
    }

    [Test]
    public void ExampleInputAlg2Test() {
        var result = Solver.SolveStar2("day2/example.txt");
        Assert.AreEqual(900, result);
    }
}
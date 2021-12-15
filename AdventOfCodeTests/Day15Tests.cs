using System.IO;
using AdventOfCode.day15;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day15Tests {
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day15/example.txt");
        Assert.AreEqual(40, result);
    }
    
    [Test]
    public void ExampleInputExpansionTest() {
        var result = Solver.ExpandedGridAsString("day15/example.txt");
        Assert.AreEqual(File.ReadAllText("day15/expanded.txt"), result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day15/example.txt");
        Assert.AreEqual(315, result);
    }
}
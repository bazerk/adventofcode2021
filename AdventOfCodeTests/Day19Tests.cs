using System.IO.Pipes;
using AdventOfCode.day19;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day19Tests {
    [Test]
    public void TestCalcDistance() {
        var a = new Beacon((0, 0, 0));
        var b = new Beacon((5, 0, 0));
        Assert.AreEqual(5.0, Beacon.CalculateDistance(a, b));
    }

    [Test]
    public void TestCompareScanners() {
        var scanners = Solver.GetData("day19/example.txt");
        var s1 = scanners[0];
        var s2 = scanners[1];
        var translated = s1.TranslateScannerIfPossible(s2);
        Assert.IsNotNull(translated);

        var s4 = translated.TranslateScannerIfPossible(scanners[3]);
        Assert.IsNotNull(s4);
    }
    
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day19/example.txt");
        Assert.AreEqual(79, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day19/example.txt");
        Assert.AreEqual(3621, result);
    }
}
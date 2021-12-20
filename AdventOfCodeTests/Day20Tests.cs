using System;
using System.IO;
using System.Linq;
using AdventOfCode.day20;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day20Tests {
    [Test]
    public void TestLoadImageData() {
        var (_, image) = Solver.GetImage("day20/example.txt");
        Assert.AreEqual($"#..#.{Environment.NewLine}" +
                        $"#....{Environment.NewLine}" +
                        $"##..#{Environment.NewLine}" +
                        $"..#..{Environment.NewLine}" +
                        $"..###{Environment.NewLine}", image.ToString());
        Assert.AreEqual(10, image.GetLitCount());
    }

    [Test]
    public void TestEnhance() {
        var (enhancer, image) = Solver.GetImage("day20/example.txt");
        var enhanced = enhancer.Enhance(image);
        Assert.AreEqual(24, enhanced.GetLitCount());
        Assert.AreEqual(false, enhancer.TestVal(0));
        Assert.AreEqual(false, enhancer.TestVal(1));
        Assert.AreEqual(true, enhancer.TestVal(2));
        Assert.AreEqual(true, enhancer.TestVal(10));
        Assert.AreEqual(true, enhancer.TestVal(20));
        Assert.AreEqual(false, enhancer.TestVal(60));
        Assert.AreEqual(false, enhancer.TestVal(70));
        Assert.AreEqual(false, enhancer.TestVal(510));
        Assert.AreEqual(true, enhancer.TestVal(511));
    }
    
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day20/example.txt");
        Assert.AreEqual(35, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day20/example.txt");
        Assert.AreEqual(3351, result);
    }
}
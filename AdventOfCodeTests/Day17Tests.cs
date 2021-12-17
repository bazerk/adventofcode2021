using AdventOfCode.day17;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day17Tests {
    [Test]
    public void TestGetTargetData() {
        var targetArea = Solver.GetData("day17/example.txt");
        Assert.AreEqual((20, -5), targetArea.TopLeftCorner);
        Assert.AreEqual((30, -10), targetArea.BottomRightCorner);
    }

    [Test]
    public void TestWithinBounds() {
        var targetArea = new TargetArea {
            TopLeftCorner = (5, -5),
            BottomRightCorner = (10, -10)
        };
        Assert.IsTrue(targetArea.WithinBounds(5, -5));
        Assert.IsTrue(targetArea.WithinBounds(10, -10));
        Assert.IsTrue(targetArea.WithinBounds(5, -7));
        Assert.IsFalse(targetArea.WithinBounds(4, -5));
        Assert.IsFalse(targetArea.WithinBounds(5, -4));
    }

    [Test]
    public void TestProveMovement() {
        var probe = new Probe((7, 2));
        probe.Move();
        Assert.AreEqual((7, 2), probe.Position);
        probe.Move();
        Assert.AreEqual((13, 3), probe.Position);
        probe.Move();
        Assert.AreEqual((18, 3), probe.Position);
    }

    [Test]
    public void MinVelocityTess() {
        var min = Solver.FindMinVelocity(5);
        Assert.AreEqual(3, min);
        
        min = Solver.FindMinVelocity(10);
        Assert.AreEqual(4, min);
        
        min = Solver.FindMinVelocity(20);
        Assert.AreEqual(6, min);
    }
    
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day17/example.txt");
        Assert.AreEqual(45, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day17/example.txt");
        Assert.AreEqual(112, result);
    }
}
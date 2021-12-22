using System.Linq;
using AdventOfCode.day22;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day22Tests {
    [Test]
    public void TestCuboidVolume() {
        var c1 = new Cuboid {
            X = (1, 3),
            Y = (1, 3),
            Z = (1, 3),
        };
        Assert.AreEqual(27, c1.GetVolume());
        var c2 = new Cuboid {
            X = (-1, 1),
            Y = (-1, 1),
            Z = (-1, 1),
        };
        Assert.AreEqual(27, c2.GetVolume());
    }

    [Test]
    public void TestCuboidIntersects() {
        var c1 = new Cuboid {
            X = (1, 3),
            Y = (1, 3),
            Z = (1, 3),
        };
        var c2 = new Cuboid{
            X = (3, 3),
            Y = (3, 3),
            Z = (3, 3),
        };
        Assert.IsTrue(c1.Intersects(c2));
        var c3 = new Cuboid{
            X = (4, 4),
            Y = (4, 4),
            Z = (4, 4),
        };
        Assert.IsFalse(c1.Intersects(c3));
    }

    [Test]
    public void TestCuboidRemoveLeftEdge() {
        var c1 = new Cuboid {
            X = (1, 3),
            Y = (1, 3),
            Z = (1, 3),
        };
        var remove = new Cuboid {
            X = (1, 1),
            Y = (1, 3),
            Z = (1, 3),
        };
        var split = c1.Remove(remove);
        var sum = split.Sum(c => c.GetVolume());
        Assert.AreEqual(18, sum);
    }
    
    [Test]
    public void TestCuboidRemoveRightEdge() {
        var c1 = new Cuboid {
            X = (1, 3),
            Y = (1, 3),
            Z = (1, 3),
        };
        var remove = new Cuboid {
            X = (3, 3),
            Y = (1, 3),
            Z = (1, 3),
        };
        var split = c1.Remove(remove);
        var sum = split.Sum(c => c.GetVolume());
        Assert.AreEqual(18, sum);
    }
    
    [Test]
    public void TestCuboidRemoveMiddleX() {
        var c1 = new Cuboid {
            X = (1, 3),
            Y = (1, 3),
            Z = (1, 3),
        };
        var remove = new Cuboid {
            X = (2, 2),
            Y = (1, 3),
            Z = (1, 3),
        };
        var split = c1.Remove(remove);
        var sum = split.Sum(c => c.GetVolume());
        Assert.AreEqual(18, sum);
    }
    
    [Test]
    public void TestCuboidRemoveMiddleCube() {
        var c1 = new Cuboid {
            X = (1, 3),
            Y = (1, 3),
            Z = (1, 3),
        };
        var remove = new Cuboid {
            X = (2, 2),
            Y = (2, 2),
            Z = (2, 2),
        };
        var split = c1.Remove(remove);
        var sum = split.Sum(c => c.GetVolume());
        Assert.AreEqual(26, sum);
    }

    [Test]
    public void TestCuboidRemoveNullOp() {
        var c1 = new Cuboid {
            X = (13, 13),
            Y = (11, 13),
            Z = (11, 13),
        };
        var remove = new Cuboid {
            X = (9, 11),
            Y = (9, 11),
            Z = (9, 11),
        };
        var split = c1.Remove(remove);
        var sum = split.Sum(c => c.GetVolume());
        Assert.AreEqual(9, sum);
    }

    [Test]
    public void SmallExampleInputStar1Test() {
        var result = Solver.SolveStar1("day22/example1.txt");
        Assert.AreEqual(39, result);
    }
    
    [Test]
    public void MediumExampleInputStar1Test() {
        var result = Solver.SolveStar1("day22/example2.txt");
        Assert.AreEqual(590784, result);
    }
 
    [Test]
    public void SmallExampleInputStar2Test() {
        var result = Solver.SolveStar2("day22/example1.txt");
        Assert.AreEqual(39, result);
    }
    
    [Test]
    public void BigInputStar2Test() {
        var result = Solver.SolveStar2("day22/example3.txt");
        Assert.AreEqual(2758514936282235, result);
    }
}
using AdventOfCode.day18;
using NUnit.Framework;

namespace AdventOfCodeTests;

public class Day18Tests {
    [Test]
    public void TestSimpleAddition() {
        var a = new SnailfishNumber(1, 1);
        var b = new SnailfishNumber(2, 2);
        var sum = SnailfishNumber.Add(a, b);
        Assert.AreEqual("[[1,1],[2,2]]", sum.ToString());
    }

    [Test]
    public void TestGetData() {
        var number = Solver.GetData("[[1,2],[[3,4],5]]");
        Assert.AreEqual("[[1,2],[[3,4],5]]", number.ToString());
        number = Solver.GetData("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]");
        Assert.AreEqual("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", number.ToString());
    }

    [Test]
    public void TestGetMagnitude() {
        var number = Solver.GetData("[[1,2],[[3,4],5]]");
        Assert.AreEqual(143, number.GetMagnitude());
        number = Solver.GetData("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]");
        Assert.AreEqual(3488, number.GetMagnitude());
    }

    [Test]
    public void TestExplode() {
        var number = Solver.GetData("[[[[[9,8],1],2],3],4]");
        number.Reduce();
        Assert.AreEqual("[[[[0,9],2],3],4]", number.ToString());
        
        number = Solver.GetData("[7,[6,[5,[4,[3,2]]]]]");
        number.Reduce();
        Assert.AreEqual("[7,[6,[5,[7,0]]]]", number.ToString());
        
        number = Solver.GetData("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]");
        number.Reduce();
        Assert.AreEqual("[[3,[2,[8,0]]],[9,[5,[7,0]]]]", number.ToString());
    }

    [Test]
    public void TestSplit() {
        var number = new SnailfishNumber(10, 11);
        number.Reduce();
        Assert.AreEqual("[[5,5],[5,6]]", number.ToString());
    }
    
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day18/example.txt");
        Assert.AreEqual(4140, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day18/example.txt");
        Assert.AreEqual(3993, result);
    }
}
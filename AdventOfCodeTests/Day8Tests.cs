using System.Collections.Generic;
using AdventOfCode.day8;
using NUnit.Framework;

namespace AdventOfCodeTests; 

public class Day8Tests {
    [Test]
    public void ExampleInputStar1Test() {
        var result = Solver.SolveStar1("day8/example.txt");
        Assert.AreEqual(26, result);
    }
    
    [Test]
    public void ExampleInputStar2Test() {
        var result = Solver.SolveStar2("day8/example.txt");
        Assert.AreEqual(61229, result);
    }

    [Test]
    public void ExampleInputSingleLineStar2Test() {
        var result = Solver.SolveStar2("day8/line.txt");
        Assert.AreEqual(1625, result);
    }
    
    private (Dictionary<char, List<char>>, Dictionary<int, string?>) BuildInitialCandidates() {
        var candidates = new Dictionary<char, List<char>>();
        for (var ch = 'a'; ch <= 'g'; ch++) {
            candidates[ch] = new List<char>(Digit.AllSegments);
        }

        var seen = new Dictionary<int, string?>();
        for (var dgt = 0; dgt < 10; dgt++) {
            seen[dgt] = null;
        }

        return (candidates, seen);
    }
    
    [Test]
    public void DigitReduceTests() {
        var (candidates, seen) = BuildInitialCandidates();

        var digit1 = new Digit("ab");
        digit1.Reduce(candidates, seen);
        Assert.AreEqual(digit1.Value, 1);
        
        var digit7 = new Digit("dab");
        digit7.Reduce(candidates, seen);
        Assert.AreEqual(digit7.Value, 7);
        Assert.AreEqual('d', candidates['a'][0]);

        var digit3 = new Digit("fbcad");
        digit3.Reduce(candidates, seen);
        Assert.AreEqual(digit3.Value, 3);

        var digit6 = new Digit("cdfgeb");
        digit6.Reduce(candidates, seen);
        Assert.AreEqual(digit6.Value, 6);

        (candidates, seen) = BuildInitialCandidates();
        digit6 = new Digit("cdfgeb");
        digit6.Reduce(candidates, seen);
        Assert.IsNull(digit6.Value);
    }
}
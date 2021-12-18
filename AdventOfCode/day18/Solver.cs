namespace AdventOfCode.day18;

public static class Solver {

    public static SnailfishNumber GetData(string input) {
        var values = new Stack<object>();
        foreach (var ch in input) {
            if (Char.IsDigit(ch)) {
                var asInt = int.Parse(ch.ToString());
                values.Push(asInt);
            }

            if (ch == ']') {
                var right = values.Pop();
                var left = values.Pop();
                var number = new SnailfishNumber(left, right);
                values.Push(number);
            }
        }

        return (SnailfishNumber)values.Pop();
    }
    
    public static int SolveStar1(string filename = "day18/input1.txt") {
        SnailfishNumber? sn = null;
        foreach (var line in File.ReadLines(filename)) {
            if (sn is null) {
                sn = GetData(line);
                continue;
            }
            sn = SnailfishNumber.Add(sn, GetData(line));
            sn.Reduce();
        }

        if (sn is null) {
            throw new ArgumentException();
        }
        return sn.GetMagnitude();
    }
    
    public static int SolveStar2(string filename = "day18/input1.txt") {
        var highestMagnitude = int.MinValue;
        var snailfishStrings = File.ReadAllLines(filename).ToList();
        for (var ixLeft = 0; ixLeft < snailfishStrings.Count; ixLeft++) {
            for (var ixRight = 0; ixRight < snailfishStrings.Count; ixRight++) {
                if (ixLeft == ixRight) continue;
                var l1 = snailfishStrings[ixLeft];
                var l2 = snailfishStrings[ixRight];
                var sn = SnailfishNumber.Add(GetData(l1), GetData(l2));
                sn.Reduce();
                var mag = sn.GetMagnitude();
                if (mag > highestMagnitude) {
                    highestMagnitude = mag;
                }
                sn = SnailfishNumber.Add(GetData(l2), GetData(l1));
                sn.Reduce();
                mag = sn.GetMagnitude();
                if (mag > highestMagnitude) {
                    highestMagnitude = mag;
                }
            }
        }

        return highestMagnitude;
    }
}
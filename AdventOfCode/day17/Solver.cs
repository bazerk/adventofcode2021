using System.Text.RegularExpressions;

namespace AdventOfCode.day17; 

public static class Solver {
    public static TargetArea GetData(string filename) {
        var regex = new Regex(@"target area: x=(?<x1>[\-0-9]+)..(?<x2>[\-0-9]+), y=(?<y2>[\-0-9]+)..(?<y1>[\-0-9]+)");
        var text = File.ReadAllText(filename);
        var match = regex.Match(text);
        var x1 = int.Parse(match.Groups["x1"].Value);
        var x2 = int.Parse(match.Groups["x2"].Value);
        var y1 = int.Parse(match.Groups["y1"].Value);
        var y2 = int.Parse(match.Groups["y2"].Value);

        return new TargetArea {
            TopLeftCorner = (x1, y1),
            BottomRightCorner = (x2, y2)
        };
    }

    public static int FindMinVelocity(int posX) {
        var x = 1;
        while (true) {
            var probe = new Probe((x, 0));
            while (probe.Position.Item1 < posX) {
                probe.Move();
                if (probe.Velocity.Item1 == 0) break;
            }

            if (probe.Position.Item1 >= posX) return x;
            x++;
        }
    }
    
    public static int SolveStar1(string filename = "day17/input1.txt") {
        var highestYSeen = int.MinValue;
        var targetArea = GetData(filename);
        var (leftX, topY) = targetArea.TopLeftCorner;
        var (rightX, bottomY) = targetArea.BottomRightCorner;

        var minVelocityX = FindMinVelocity(leftX);
        var maxVelocityX = rightX;

        for (var velocityX = minVelocityX; velocityX <= maxVelocityX; velocityX++) {
            var velocityY = 1;

            // There is probably a smart way of not needing an upper bound here and knowing when to bail on a y due
            // to the download velocity being too fast.
            while (velocityY < 1000) {
                var solvedForThisX = false;
                TargetAreaTest currentResult;

                var probe = new Probe((velocityX, velocityY));
                var thisRunHighestY = int.MinValue;
                // If we overshoot x- y is too big - break, if we undershoot - y is to small, we increase 
                while (true) {
                    probe.Move();
                    var (px, py) = probe.Position;
                    if (py > thisRunHighestY) {
                        thisRunHighestY = py;
                    }
                    currentResult = probe.TestTarget(targetArea);

                    if (currentResult == TargetAreaTest.InArea) {
                        solvedForThisX = true;

                        if (thisRunHighestY > highestYSeen) {
                            highestYSeen = thisRunHighestY;
                        }

                        break;
                    }

                    if (currentResult != TargetAreaTest.Unknown) {
                        break;
                    }
                }

                if (currentResult == TargetAreaTest.OvershotX) {
                    break;
                }

                // Shooting too high
                if (solvedForThisX) {
                    if (currentResult is TargetAreaTest.UndershotX or TargetAreaTest.UndershotY) {
                        break;
                    }
                }

                velocityY++;
            }
        }
        
        return highestYSeen;
    }
    
    public static int SolveStar2(string filename = "day17/input1.txt") {
        var solutions = new HashSet<(int, int)>();
        var targetArea = GetData(filename);
        var (leftX, topY) = targetArea.TopLeftCorner;
        var (rightX, bottomY) = targetArea.BottomRightCorner;

        var minVelocityX = FindMinVelocity(leftX);
        var maxVelocityX = rightX;

        for (var velocityX = minVelocityX; velocityX <= maxVelocityX; velocityX++) {
            var velocityY = bottomY;

            // There is probably a smart way of not needing an upper bound here and knowing when to bail on a y due
            // to the download velocity being too fast.
            while (velocityY < 1000) {
                var solvedForThisX = false;
                TargetAreaTest currentResult;

                var probe = new Probe((velocityX, velocityY));
                // If we overshoot x- y is too big - break, if we undershoot - y is to small, we increase 
                while (true) {
                    probe.Move();
                    var (px, py) = probe.Position;
                    currentResult = probe.TestTarget(targetArea);

                    if (currentResult == TargetAreaTest.InArea) {
                        solutions.Add((velocityX, velocityY));
                        solvedForThisX = true;
                        break;
                    }

                    if (currentResult != TargetAreaTest.Unknown) {
                        break;
                    }
                }

                if (currentResult == TargetAreaTest.OvershotX) {
                    break;
                }

                // Shooting too high
                if (solvedForThisX) {
                    if (currentResult is TargetAreaTest.UndershotX or TargetAreaTest.UndershotY) {
                        break;
                    }
                }

                velocityY++;
            }
        }
        
        return solutions.Count;
    }
}
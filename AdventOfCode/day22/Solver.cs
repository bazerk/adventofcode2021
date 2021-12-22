using System.Text.RegularExpressions;

namespace AdventOfCode.day22; 

public static class Solver {

    public static List<InitialisationStep> GetData(string filename) {
        //on x=-20..26,y=-36..17,z=-47..7
        var steps = new List<InitialisationStep>();
        var regex = new Regex(@"(on|off) x=(?<x1>[\-0-9]+)..(?<x2>[\-0-9]+),y=(?<y1>[\-0-9]+)..(?<y2>[\-0-9]+),z=(?<z1>[\-0-9]+)..(?<z2>[\-0-9]+)");
        foreach (var line in File.ReadLines(filename)) {
            var on = line.StartsWith("on");
            var match = regex.Match(line);
            var x1 = int.Parse(match.Groups["x1"].Value);
            var x2 = int.Parse(match.Groups["x2"].Value);
            var y1 = int.Parse(match.Groups["y1"].Value);
            var y2 = int.Parse(match.Groups["y2"].Value);
            var z1 = int.Parse(match.Groups["z1"].Value);
            var z2 = int.Parse(match.Groups["z2"].Value);
            steps.Add(new InitialisationStep {
                On=on,
                X=(x1, x2),
                Y=(y1, y2),
                Z=(z1, z2)
            });
        }
        return steps;
    }
    
    public static int SolveStar1(string filename = "day22/input1.txt") {
        // We know the naive solution isn't going to scale for star 2 - but wait till we see what star2 needs before
        // doing something smart
        var data = GetData(filename);
        var grid = new bool[101, 101, 101];
        var count = 0;
        foreach (var step in data) {
            var (x1, x2) = step.X;
            x1 += 50;
            x2 += 50;
            var (y1, y2) = step.Y;
            y1 += 50;
            y2 += 50;
            var (z1, z2) = step.Z;
            z1 += 50;
            z2 += 50;
            if ((Math.Abs(x1) > 100 || Math.Abs(x2) > 100) ||
                (Math.Abs(y1) > 100 || Math.Abs(y2) > 100) ||
                (Math.Abs(z1) > 100 || Math.Abs(z2) > 100)) {
                continue;
            }
            for (var x = x1; x <= x2; x++) {
                for (var y = y1; y <= y2; y++) {
                    for (var z = z1; z <= z2; z++) {
                        if (step.On && !grid[x, y, z]) {
                            count++;
                        } else if (grid[x, y, z] && !step.On) {
                            count--;
                        }
                        grid[x, y, z] = step.On;
                    }
                }
            }
        }

        return count;
    }

    public static long SolveStar2(string filename = "day22/input1.txt") {
        // We'll have to represent the space as cuboids which are on, and break up big ones into small ones when
        // cuboids intersect
        var data = GetData(filename);
        var cuboids = new List<Cuboid>();
        foreach (var step in data) {
            var newCuboids = new List<Cuboid> {new() {X = step.X, Y = step.Y, Z = step.Z}};
            if (step.On) {
                foreach (var existing in cuboids) {
                    var toTest = newCuboids;
                    newCuboids = new List<Cuboid>();
                    foreach (var newCuboid in toTest) {
                        var remainder = existing.Intersect(newCuboid);
                        newCuboids.AddRange(remainder);
                    }

                    if (newCuboids.Count == 0) break;
                }

                cuboids.AddRange(newCuboids);
            } else {
                var currentSet = cuboids;
                cuboids = new List<Cuboid>();
                var turnOff = new Cuboid {X = step.X, Y = step.Y, Z = step.Z};
                foreach (var existing in currentSet) {
                    var split = existing.Remove(turnOff);
                    cuboids.AddRange(split);
                }
            }
        }
        return cuboids.Sum(c => c.GetVolume());
    }
}
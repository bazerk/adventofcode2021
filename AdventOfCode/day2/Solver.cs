using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.day2;

namespace AdventOfCode.day2;

public static class Solver {
    private static IEnumerable<Command> GetCommands(string inputFile) {
        var lines = File.ReadAllLines(inputFile);
        foreach (var line in lines) {
            var split = line.Split();
            var type = split[0];
            var amount = int.Parse(split[1]);

            if (type.Equals("forward")) {
                yield return new Command {
                    Type = Command.CommandType.Position,
                    Magnitude = amount
                };
            } else {
                if (type.Equals("up")) {
                    amount *= -1;
                }

                yield return new Command {
                    Type = Command.CommandType.Depth,
                    Magnitude = amount
                };
            }
        }
    }

    public static int SolveStar1(string inputFile = "day2/input1.txt") {
        var sub = new Star1Submarine();
        foreach (var command in GetCommands(inputFile)) {
            sub.FollowCommand(command);
        }
        return sub.Depth * sub.HorizontalPosition;
    }
    
    public static int SolveStar2(string inputFile = "day2/input1.txt") {
        var sub = new Star2Submarine();
        foreach (var command in GetCommands(inputFile)) {
            sub.FollowCommand(command);
        }
        return sub.Depth * sub.HorizontalPosition;
    }
}

namespace AdventOfCode.day10; 

public static class Solver {
    public static int SolveStar1(string filename = "day10/input1.txt") {
        var totalScore = 0;
        foreach (var line in File.ReadAllLines(filename)) {
            var parser = new SyntaxChecker();
            foreach (var ch in line) {
                var score = parser.PushChar(ch);
                if (score > 0) {
                    totalScore += score;
                    break;
                }
            }
        }
        return totalScore;
    }

    public static long SolveStar2(string filename = "day10/input1.txt") {
        var completionScores = new List<long>();
        foreach (var line in File.ReadAllLines(filename)) {
            var parser = new SyntaxChecker();
            var errorScore = 0;
            foreach (var ch in line) {
                errorScore = parser.PushChar(ch);
                if (errorScore > 0) {
                    break;
                }
            }

            if (errorScore == 0) {
                completionScores.Add(parser.CompletionScore());
            }
        }

        var sortedScores = completionScores.OrderBy(sc => sc).ToList();
        return sortedScores[sortedScores.Count / 2];
    }
}
namespace AdventOfCode.day21; 

public static class Solver {

    public static (int, int) GetStartingPositions(string filename) {
        var lines = File.ReadAllLines(filename);
        var p1 = int.Parse(lines[0].Substring("Player 1 starting position: ".Length));
        var p2 = int.Parse(lines[1].Substring("Player 2 starting position: ".Length));
        return (p1, p2);
    }
    
    public static int SolveStar1(string filename = "day21/input1.txt") {
        var (p1Pos, p2Pos) = GetStartingPositions(filename);
        var p1 = new Player {Position = p1Pos};
        var p2 = new Player {Position = p2Pos};
        var dice = new DeterministicDice();

        int RollDice() => dice.Roll() + dice.Roll() + dice.Roll();

        while (!p1.Won && !p2.Won) {
            if (p1.Move(RollDice())) break;
            if (p2.Move(RollDice())) break;
        }

        return dice.RollCount * Math.Min(p1.Score, p2.Score);
    }

    public static IEnumerable<int> QuantumRollValues() {
        for (var d1 = 1; d1 <= 3; d1++) {
            for (var d2 = 1; d2 <= 3; d2++) {
                for (var d3 = 1; d3 <= 3; d3++) {
                    yield return d1 + d2 + d3;
                }
            }
        }
    }

    public static long SolveStar2(string filename = "day21/input1.txt") {
        var (p1Initial, p2Initial) = GetStartingPositions(filename);
        var p1Wins = 0L;
        var p2Wins = 0L;
        var inPlayPositions = new Dictionary<(int, int, int, int), long> {
            {(p1Initial, 0, p2Initial, 0), 1L}
        };
        var rolls = QuantumRollValues().ToArray();

        while (inPlayPositions.Count > 0) {
            var kv = inPlayPositions.First();
            inPlayPositions.Remove(kv.Key);
            var (p1Pos, p1Score, p2Pos, p2Score) = kv.Key;
            var universes = kv.Value;
            
            // First move p1
            foreach (var p1Roll in rolls) {
                var p1NewPos = (p1Pos + p1Roll) % 10;
                if (p1NewPos == 0) p1NewPos = 10;
                var p1NewScore = p1Score + p1NewPos;
                if (p1NewScore >= 21) {
                    p1Wins += universes;
                    continue;
                }
                
                // Then move p2
                foreach (var p2Roll in rolls) {
                    var p2NewPos = (p2Pos + p2Roll) % 10;
                    if (p2NewPos == 0) p2NewPos = 10;
                    var p2NewScore = p2Score + p2NewPos;
                    if (p2NewScore >= 21) {
                        p2Wins += universes;
                        continue;
                    }

                    var key = (p1NewPos, p1NewScore, p2NewPos, p2NewScore);
                    inPlayPositions.TryAdd(key, 0L);
                    inPlayPositions[key] += universes;
                }
            }
        }
        
        
        return Math.Max(p1Wins, p2Wins);
    }
}
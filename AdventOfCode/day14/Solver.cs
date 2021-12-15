using System.Text;

namespace AdventOfCode.day14; 

public static class Solver {
    private static (string, Dictionary<string, string>) GetData(string filename) {
        var lines = File.ReadLines(filename).ToList();
        var initialState = lines[0];
        var subs = new Dictionary<string, string>();
        for (var ix = 2; ix < lines.Count; ix++) {
            var line = lines[ix];
            var split = line.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            subs[split[0]] = split[1];
        }

        return (initialState, subs);
    }

    private static string Process(string input, Dictionary<string, string> subs) {
        var output = new StringBuilder(input.Length * 2);
        for (var ix = 0; ix < input.Length; ix++) {
            output.Append(input[ix]);
            if (ix == input.Length - 1) break;
            var key = input.Substring(ix, 2);
            output.Append(subs[key]);
        }
        return output.ToString();
    }
    
    public static int SolveStar1(string filename = "day14/input1.txt") {
        var (state, subs) = GetData(filename);
        Console.WriteLine();
        foreach (var ix in Enumerable.Range(0, 10)) {
            state = Process(state, subs);
            Console.WriteLine(state);
        }

        var charCount = new Dictionary<char, int>();
        foreach (var ch in state) {
            if (!charCount.ContainsKey(ch)) {
                charCount[ch] = 1;
            } else {
                charCount[ch] += 1;
            }
        }

        var ordered = charCount.Select(kv => kv).OrderBy(kv => kv.Value).ToList();
        var smallest = ordered.First().Value;
        var largest = ordered.Last().Value;

        return largest - smallest;
    }

    public static long SolveStar2(string filename = "day14/input1.txt") {
        var (state, subs) = GetData(filename);
        var pairCounter = new PairCounter(state, subs);
        while (pairCounter.Generation < 40) {
            pairCounter.Step();
        }
        
        var ordered = pairCounter.GetOrderedCharCounts();
        var smallest = ordered.First().Item2;
        var largest = ordered.Last().Item2;

        return largest - smallest;
    }
}
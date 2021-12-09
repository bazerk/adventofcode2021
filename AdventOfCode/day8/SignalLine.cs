namespace AdventOfCode.day8; 

public class SignalLine {
    public List<Digit> Output { get; }

    private readonly List<Digit> _signalPatterns;
    private readonly Dictionary<char, List<char>> _candidates = new();
    private readonly Dictionary<int, string?> _seen = new();

    public SignalLine(IEnumerable<Digit> signalPatterns, IEnumerable<Digit> output) {
        _signalPatterns = signalPatterns.ToList();
        Output = output.ToList();

        for (var ch = 'a'; ch <= 'g'; ch++) {
            _candidates[ch] = new List<char>(Digit.AllSegments);
        }

        for (var dgt = 0; dgt < 10; dgt++) {
            _seen[dgt] = null;
        }
    }

    public int Decode() {
        var unsolved = true;
        while (unsolved) {
            var candidatesUpdated = false;
            unsolved = false;
            foreach (var digit in _signalPatterns) {
                if (digit.Reduce(_candidates, _seen)) {
                    candidatesUpdated = true;
                }

                if (digit.Value is null) {
                    unsolved = true;
                }
            }

            if (!candidatesUpdated && unsolved) {
                throw new InvalidDataException("There is a problem!");
            }
        }

        var solved = new Dictionary<string, int>(); 
        foreach (var (k, v) in _seen) {
            solved[String.Concat(v.OrderBy(c => c))] = k;
        }

        var outputStr = "";
        foreach (var value in Output) {
            var sorted = String.Concat(value.Segments.OrderBy(c => c));
            outputStr += solved[sorted].ToString();
        }

        return int.Parse(outputStr);
    }
}
namespace AdventOfCode.day10; 

public class SyntaxChecker {
    private readonly Stack<char> _parenStack = new();
    private readonly Dictionary<char, char> _matches = new() {
        {'(', ')'},
        {'[', ']'},
        {'{', '}'},
        {'<', '>'},
    };
    private readonly Dictionary<char, int> _errorScores = new() {
        {')', 3},
        {']', 57},
        {'}', 1197},
        {'>', 25137},
    };
    private readonly Dictionary<char, int> _completionScores = new() {
        {')', 1},
        {']', 2},
        {'}', 3},
        {'>', 4},
    };
    
    public int PushChar(char ch) {
        if (_matches.ContainsKey(ch)) {
            _parenStack.Push(ch);
            return 0;
        }

        if (!_parenStack.TryPop(out var pairedChar)) {
            return _errorScores[ch];
        }

        var test = _matches[pairedChar];
        if (test == ch) {
            return 0;
        }
        return _errorScores[ch];
    }

    public long CompletionScore() {
        var score = 0L;
        while (_parenStack.Count > 0) {
            var opening = _parenStack.Pop();
            var closing = _matches[opening];
            score *= 5;
            score += _completionScores[closing];
        }
        return score;
    }
}

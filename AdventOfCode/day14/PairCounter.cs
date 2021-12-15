namespace AdventOfCode.day14;

public class PairCounter {

    public int Generation { get; private set; }
    
    private char _finalChar;
    private Dictionary<string, long> _pairCounts = new();
    private Dictionary<string, string> _subs;

    public PairCounter(string initialState, Dictionary<string, string> subs) {
        _subs = subs;
        for (var ix = 0; ix < initialState.Length; ix++) {
            if (ix == initialState.Length - 1) {
                _finalChar = initialState[ix];
                break;
            }
            var pair = initialState.Substring(ix, 2);
            CountPair(_pairCounts, pair, 1);
        }
    }

    private void CountPair(Dictionary<string, long> store, string pair, long count) {
        store.TryAdd(pair, 0);
        store[pair] += count;
    }

    public void Step() {
        Generation += 1;
        var newPairs = new Dictionary<string, long>();
        foreach (var kv in _pairCounts) {
            var pair1 = kv.Key[0] + _subs[kv.Key];
            CountPair(newPairs, pair1, kv.Value);
            var pair2 = _subs[kv.Key] + kv.Key[1];
            CountPair(newPairs, pair2, kv.Value);
        }
        _pairCounts = newPairs;
    }

    public List<(char, long)> GetOrderedCharCounts() {
        var counts = new Dictionary<char, long>();
        counts[_finalChar] = 1;
        foreach (var kv in _pairCounts) {
            counts.TryAdd(kv.Key[0], 0);
            counts[kv.Key[0]] += kv.Value;
        }

        return counts.OrderBy(kv => kv.Value).Select(kv => (kv.Key, kv.Value)).ToList();
    } 
}
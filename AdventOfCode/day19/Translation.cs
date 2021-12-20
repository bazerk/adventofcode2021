namespace AdventOfCode.day19; 

public class Translation {
    private readonly Dictionary<char, char> _colMap;
    private readonly Dictionary<char, int> _signMap;
    
    public Translation(Dictionary<char, char> colMap, Dictionary<char, int> signMap) {
        _colMap = colMap;
        _signMap = signMap;
    }

    public (int, int, int) TranslateBeacon(Beacon b) {
        var (x, y, z) = b.Position;
        x *= _signMap['x'];
        y *= _signMap['y'];
        z *= _signMap['z'];

        var translated = new Dictionary<char, int> {
            [_colMap['x']] = x,
            [_colMap['y']] = y,
            [_colMap['z']] = z
        };

        return (translated['x'], translated['y'], translated['z']);
    }
}
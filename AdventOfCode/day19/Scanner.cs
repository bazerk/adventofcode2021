namespace AdventOfCode.day19; 

public class Scanner {
    public int ScannerNumber { get; }
    public List<Beacon> Beacons { get; } = new();
    
    public (int, int, int) OriginalPosition { get; set; }
    
    public Scanner(int scannerNumber, IEnumerable<(int, int, int)> relativeBeaconCoordinates) {
        ScannerNumber = scannerNumber;
        Beacons.AddRange(relativeBeaconCoordinates.Select(c => new Beacon(c)));
        CalculateDistances();
    }
    
    private void CalculateDistances() {
        foreach (var b1 in Beacons) {
            foreach (var b2 in Beacons) {
                if (b1 == b2) continue;
                b1.AddNeighbour(b2);
                b2.AddNeighbour(b1);
            }
        }
    }

    private int MatchingEntries(List<double> a, List<double> b) {
        var identicalEntries = 0;
        var ixA = 0;
        var ixB = 0;
        while (ixA < a.Count && ixB < b.Count) {
            var aVal = a[ixA];
            var bVal = b[ixB];
            if (Math.Abs(aVal - bVal) < .1) {
                identicalEntries++;
                ixA++;
                ixB++;
                continue;
            }

            if (aVal < bVal) {
                ixA++;
                continue;
            }

            ixB++;
        }

        return identicalEntries;
    }

    public Scanner? TranslateScannerIfPossible(Scanner otherScanner) {
        var matches = new List<(Beacon, Beacon)>();
        foreach (var ourBeacon in Beacons) {
            foreach (var theirBeacon in otherScanner.Beacons) {
                var n1 = ourBeacon.NeighbourDistances.OrderBy(x => x).ToList();
                var n2 = theirBeacon.NeighbourDistances.OrderBy(x => x).ToList();
                var matchCount = MatchingEntries(n1, n2);
                if (matchCount >= 12) {
                    matches.Add((ourBeacon, theirBeacon));
                }
            }
        }

        if (matches.Count >= 12) {
            var translation = FindTranslation(matches);
            var (x1, y1, z1) = matches[0].Item1.Position;
            var (x2, y2, z2) = translation.TranslateBeacon(matches[0].Item2);
            var xShift = x1 - x2;
            var yShift = y1 - y2;
            var zShift = z1 - z2;

            var newCoords = new List<(int, int, int)>();
            foreach (var beacon in otherScanner.Beacons) {
                var (x, y, z) = translation.TranslateBeacon(beacon);
                newCoords.Add((x + xShift, y + yShift, z + zShift));
            }

            var translated = new Scanner(otherScanner.ScannerNumber, newCoords);
            translated.OriginalPosition = (xShift, yShift, zShift);
            return translated;
        }

        return null;
    }

    private Translation FindTranslation(List<(Beacon, Beacon)> matches) {
        List<int> GetData(bool source, char col) {
            var beacons = source ? matches.Select(m => m.Item1) : matches.Select(m => m.Item2);
            switch (col) {
                case 'x': return beacons.Select(b => b.Position.Item1).ToList();
                case 'y': return beacons.Select(b => b.Position.Item2).ToList();
                case 'z': return beacons.Select(b => b.Position.Item3).ToList();
            }

            throw new ArgumentException();
        }
        List<int> CalcDifferences(List<int> input) {
            var differences = new List<int>();
            for (var ix = 1; ix < input.Count; ix++) {
                differences.Add(Math.Abs(input[ix-1] - input[ix]));
            }
            return differences;
        }

        var available = new List<char> {'x', 'y', 'z'};
        var colMap = new Dictionary<char, char>();
        var signMap = new Dictionary<char, int>();
        foreach (var col in new [] {'x', 'y', 'z'}) {
            var source = GetData(true, col);
            var sourceDiff = CalcDifferences(source);
            foreach (var test in available) {
                var testCol = GetData(false, test);
                var testDiff = CalcDifferences(testCol);
                if (sourceDiff.SequenceEqual(testDiff)) {
                    available.Remove(test);
                    colMap[test] = col;

                    var ixSignTest = 0;
                    while (!signMap.ContainsKey(test)) {
                        if (source[ixSignTest] == source[ixSignTest + 1]) {
                            ixSignTest++;
                            continue;
                        }
                        signMap[test] = 1;
                        if ((source[ixSignTest + 1] > source[ixSignTest] && testCol[ixSignTest + 1] < testCol[ixSignTest]) || 
                            (source[ixSignTest + 1] < source[ixSignTest] && testCol[ixSignTest + 1] > testCol[ixSignTest])) {
                            signMap[test] = -1;
                        }
                    }

                    break;
                }
            }
        }

        return new Translation(colMap, signMap);
    }

    public override string ToString() {
        return $"--- scanner {ScannerNumber} --- ({OriginalPosition})";
    }
}
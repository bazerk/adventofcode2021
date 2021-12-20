namespace AdventOfCode.day19; 

public static class Solver {

    public static List<Scanner> GetData(string filename) {
        var scanners = new List<Scanner>();
        var coords = new List<(int, int, int)>();
        var scannerNumber = -1;
        
        foreach (var line in File.ReadLines(filename)) {
            if (String.IsNullOrEmpty(line)) continue;
            if (line.StartsWith("--- scanner ")) {
                if (coords.Count > 0) {
                    scanners.Add(new Scanner(scannerNumber, coords));
                }

                scannerNumber++;
                coords = new List<(int, int, int)>();
                continue;
            }

            var split = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            coords.Add((int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])));
        }
        scanners.Add(new Scanner(scannerNumber, coords));
        return scanners;
    }
    
    public static int SolveStar1(string filename = "day19/input1.txt") {
        var scanners = GetData(filename);
        var rationalised = Rationaliser.Solve(scanners);
        var coords = new HashSet<(int, int, int)>();
        foreach (var beacon in rationalised.SelectMany(b => b.Beacons)) {
            coords.Add(beacon.Position);
        }
        return coords.Count;
    }
    
    public static int SolveStar2(string filename = "day19/input1.txt") {
        var scanners = GetData(filename);
        var rationalised = Rationaliser.Solve(scanners);
        var biggestDistance = int.MinValue;
        foreach (var scanner in rationalised) {
            foreach (var test in rationalised) {
                var x = Math.Abs(scanner.OriginalPosition.Item1 - test.OriginalPosition.Item1);
                var y = Math.Abs(scanner.OriginalPosition.Item2 - test.OriginalPosition.Item2);
                var z = Math.Abs(scanner.OriginalPosition.Item3 - test.OriginalPosition.Item3);
                var md = x + y + z;
                if (md > biggestDistance) {
                    biggestDistance = md;
                }
            }
        }

        return biggestDistance;
    }
}
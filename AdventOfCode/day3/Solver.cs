namespace AdventOfCode.day3; 

public static class Solver {

    private static (long, long) GetGammaAndEpsilon(string filename) {
        var counts = new Dictionary<int, int>();
        var totalLines = 0;
        var numBits = 0;
        foreach (var line in File.ReadLines(filename)) {
            if (totalLines == 0) {
                numBits = line.Length;
                for (var ix = 0; ix < line.Length; ix++) {
                    counts[ix] = 0;
                }
            }

            totalLines += 1;
            for (var ix = 0; ix < line.Length; ix++) {
                if (line[ix] == '1') {
                    counts[ix] += 1;
                }
            }
        }

        string gamma = "";
        string epsilon = "";
        int threshold = totalLines / 2;
        for (var ix = 0; ix < numBits; ix++) {
            if (counts[ix] >= threshold) {
                gamma += "1";
                epsilon += "0";
            } else {
                gamma += "0";
                epsilon += "1";
            }
        }

        return (Convert.ToInt64(gamma, 2), Convert.ToInt64(epsilon, 2));
    }
    
    public static long SolveStar1(string filename = "day3/input1.txt") {
        (long gamma, long ep) = GetGammaAndEpsilon(filename);
        return gamma * ep;
    }

    public static long FilterList(List<string> data, bool mostCommon, int digit) {
        if (data.Count == 0) {
            throw new ArgumentException("empty list");
        }
        if (data.Count == 1) {
            return Convert.ToInt64(data[0], 2);
        }

        var count = data.Count(s => s[digit] == '1');
        var diff = data.Count - count;
        var filter = '1';
        if (mostCommon && count < diff) {
            filter = '0';
        } else if (!mostCommon && count >= diff) {
            filter = '0';
        }

        var filtered = data.Where(s => s[digit] == filter).ToList();
        return FilterList(filtered, mostCommon, digit + 1);
    }

    public static long SolveStar2(string filename = "day3/input1.txt") {
        var data = File.ReadAllLines(filename).ToList();
        var oxygen = FilterList(data, true, 0);
        var co2 = FilterList(data, false, 0);
        return oxygen * co2;
    }
}
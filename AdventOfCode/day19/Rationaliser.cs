namespace AdventOfCode.day19; 

public static class Rationaliser {

    public static List<Scanner> Solve(List<Scanner> scanners) {
        var rationalised = new List<Scanner> {
            scanners[0]
        };
        var unsolved = new List<Scanner>();
        unsolved.AddRange(scanners.Skip(1));

        var count = unsolved.Count;

        while (count > 0) {
            foreach (var scanner in unsolved) {
                Scanner? translated = null;
                foreach (var solved in rationalised) {
                    translated = solved.TranslateScannerIfPossible(scanner);
                    if (translated != null) {
                        unsolved.Remove(scanner);
                        rationalised.Add(translated);
                        break;
                    }
                }

                if (translated != null) break;
            }

            if (count == unsolved.Count) throw new ArgumentException();
            count = unsolved.Count;
        }

        return rationalised;
    }
}
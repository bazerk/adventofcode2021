namespace AdventOfCode.day8; 

//   0:      1:      2:      3:      4:
//  aaaa    ....    aaaa    aaaa    ....
// b    c  .    c  .    c  .    c  b    c
// b    c  .    c  .    c  .    c  b    c
//  ....    ....    dddd    dddd    dddd
// e    f  .    f  e    .  .    f  .    f
// e    f  .    f  e    .  .    f  .    f
//  gggg    ....    gggg    gggg    ....
//
//   5:      6:      7:      8:      9:
//  aaaa    aaaa    aaaa    aaaa    aaaa
// b    .  b    .  .    c  b    c  b    c
// b    .  b    .  .    c  b    c  b    c
//  dddd    dddd    ....    dddd    dddd
// .    f  e    f  .    f  e    f  .    f
// .    f  e    f  .    f  e    f  .    f
//  gggg    gggg    ....    gggg    gggg

public class Digit {
    public static readonly char[] AllSegments = {'a', 'b', 'c', 'd', 'e', 'f', 'g'};
    public string Segments { get; }
    public int? Value { get; private set; }

    public Digit(string segments) {
        Segments = segments;
    }

    private bool ApplyFilter(Dictionary<char, List<char>> candidates, List<char> possiblePositions) {
        bool updatedCandidates = false;
        foreach (var segment in AllSegments) {
            var possibleValues = candidates[segment];
            var updated = possiblePositions.Contains(segment) ?
                possibleValues.Where(pv => Segments.Contains(pv)).ToList() :
                possibleValues.Where(pv => !Segments.Contains(pv)).ToList();

            if (updated.Count == 0) {
                throw new InvalidDataException("Shouldn't happen");
            }
            
            if (updated.Count != possibleValues.Count()) {
                updatedCandidates = true;
                candidates[segment] = updated;
            }
        }

        return updatedCandidates;
    }

    public bool Reduce(Dictionary<char, List<char>> candidates, Dictionary<int, string?> seen) {
        var updatedCandidates = false;

        if (Value.HasValue) {
            return false;
        }

        // This digit is a 8
        if (Segments.Length == 7) {
            Value = 8;
            seen[8] = Segments;
            return false;
        }
        
        // This digit is a 1
        if (Segments.Length == 2) {
            Value = 1;
            seen[1] = Segments;
            return ApplyFilter(candidates, new List<char> {'c', 'f'});
        }

        // This digit is a 7
        if (Segments.Length == 3) {
            Value = 7;
            seen[7] = Segments;
            return ApplyFilter(candidates, new List<char> {'a', 'c', 'f'});
        }

        // This digit is a 4
        if (Segments.Length == 4) {
            Value = 4;
            seen[4] = Segments;
            return ApplyFilter(candidates, new List<char> {'b', 'c', 'd', 'f'});
        }

        
        // This digit could be a 2,3,5
        if (Segments.Length == 5) {
            if (seen[1] != null) {
                // A 3 will be the only one with all '1' segments present
                if (candidates['c'].All(Segments.Contains) && candidates['f'].All(Segments.Contains)) {
                    Value = 3;
                    seen[3] = Segments;
                    return ApplyFilter(candidates, new List<char> {'a', 'c', 'd', 'f', 'g'});
                }
            }

            var cCandidates = candidates['c'];
            if (cCandidates.Count == 1 && !Segments.Contains(cCandidates[0])) {
                Value = 5;
                seen[5] = Segments;
                return ApplyFilter(candidates, new List<char> {'a', 'b', 'd', 'f', 'g'});
            }

            var eCandidates = candidates['e'];
            if (eCandidates.Count == 1 && Segments.Contains(eCandidates[0])) {
                Value = 2;
                seen[2] = Segments;
                return ApplyFilter(candidates, new List<char> {'a', 'c', 'd', 'e', 'g'});
            }

            var bCandidates = candidates['b'];
            if (bCandidates.Count == 1 && Segments.Contains(bCandidates[0])) {
                Value = 5;
                seen[5] = Segments;
                return ApplyFilter(candidates, new List<char> {'a', 'b', 'd', 'f', 'g'});
            }
        }
        
        // This digit could be a 0,6,9
        if (Segments.Length == 6) {
            if (seen[1] != null || seen[7] != null) {
                // A 6 will be the only one without all '1' segments present
                if (!candidates['c'].All(Segments.Contains) || !candidates['f'].All(Segments.Contains)) {
                    Value = 6;
                    seen[6] = Segments;
                    return ApplyFilter(candidates, new List<char> {'a', 'b', 'd', 'e', 'f', 'g'});
                }
            }

            if (seen[4] != null) {
                // A 9 will be the only one with all '4' segments present
                if (candidates['b'].All(Segments.Contains) && candidates['c'].All(Segments.Contains) && 
                    candidates['d'].All(Segments.Contains) && candidates['f'].All(Segments.Contains)) {
                    Value = 9;
                    seen[9] = Segments;
                    return ApplyFilter(candidates, new List<char> {'a', 'b', 'c', 'd', 'f', 'g'});
                }
            }

            var dCandidates = candidates['d'];
            if (dCandidates.Count == 1 && !Segments.Contains(dCandidates[0])) {
                Value = 0;
                seen[0] = Segments;
                return ApplyFilter(candidates, new List<char> {'a', 'b', 'c', 'e', 'f', 'g'});
            }
        }
        
        return updatedCandidates;
    }
}
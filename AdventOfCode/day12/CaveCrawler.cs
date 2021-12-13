namespace AdventOfCode.day12; 

public class CaveCrawler {
    public IEnumerable<List<Cave>> FindPathsStar1(Cave cave, HashSet<string>? smallCaves = null, List<Cave>? path = null) {
        if (smallCaves == null) smallCaves = new HashSet<string>();
        if (path == null) path = new List<Cave>();
        
        path.Add(cave);
        if (cave.IsEnd) {
            yield return path;
        }
        
        if (!cave.Big) {
            smallCaves.Add(cave.Name);
        }

        foreach (var neighbour in cave.Neighbours) {
            if (smallCaves.Contains(neighbour.Name)) {
                continue;
            }
            var newPath = new List<Cave>(path);
            var newHash = new HashSet<string>(smallCaves);
            foreach (var discovered in FindPathsStar1(neighbour, newHash, newPath)) {
                yield return discovered;
            }
        }
    }
    
    public IEnumerable<List<Cave>> FindPathsStar2(Cave cave, HashSet<string>? smallCaves = null, List<Cave>? path = null, bool visitedCaveTwice = false) {
        if (smallCaves == null) smallCaves = new HashSet<string>();
        if (path == null) path = new List<Cave>();
        
        path.Add(cave);
        if (cave.IsEnd) {
            yield return path;
            yield break;
        }
        
        if (!cave.Big) {
            smallCaves.Add(cave.Name);
        }

        foreach (var neighbour in cave.Neighbours) {
            var newVisitedTwice = visitedCaveTwice;
            if (neighbour.IsStart) continue;
            if (smallCaves.Contains(neighbour.Name)) {
                if (newVisitedTwice) continue;
                newVisitedTwice = true;
            }
            var newPath = new List<Cave>(path);
            var newHash = new HashSet<string>(smallCaves);
            foreach (var discovered in FindPathsStar2(neighbour, newHash, newPath, newVisitedTwice)) {
                yield return discovered;
            }
        }
    }
}
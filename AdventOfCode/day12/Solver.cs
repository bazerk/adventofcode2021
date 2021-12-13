namespace AdventOfCode.day12; 

public static class Solver {

    public static Cave LoadCaveSystem(string filename) {
        var caves = new Dictionary<string, Cave>();
        foreach (var line in File.ReadAllLines(filename)) {
            var split = line.Split('-', StringSplitOptions.RemoveEmptyEntries);
            var fromName = split[0];
            if (!caves.TryGetValue(fromName, out Cave? from)) {
                from = new Cave(fromName);
                caves[fromName] = from;
            }
            var toName = split[1];
            if (!caves.TryGetValue(toName, out Cave? to)) {
                to = new Cave(toName);
                caves[toName] = to;
            }
            from.AddNeighbour(to);
            to.AddNeighbour(from);
        }

        return caves[Cave.StartCaveName];
    }
    
    public static int SolveStar1(string filename = "day12/input1.txt") {
        var startCave = LoadCaveSystem(filename);
        var solver = new CaveCrawler();
        return solver.FindPathsStar1(startCave).Count();
    }

    public static int SolveStar2(string filename = "day12/input1.txt") {
        var startCave = LoadCaveSystem(filename);
        var solver = new CaveCrawler();
        return solver.FindPathsStar2(startCave).Count();
    }
}
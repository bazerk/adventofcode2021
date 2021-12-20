namespace AdventOfCode.day19; 

public class Beacon {
    public (int, int, int) Position { get; }
    public List<double> NeighbourDistances { get; } = new();

    public Beacon((int, int, int) position) {
        Position = position;
    }

    public void AddNeighbour(Beacon beacon) {
        NeighbourDistances.Add(CalculateDistance(this, beacon));
    }

    public static double CalculateDistance(Beacon a, Beacon b) {
        var (ax, ay, az) = a.Position;
        var (bx, by, bz) = b.Position;

        var squared = Math.Pow(ax - bx, 2) + Math.Pow(ay - by, 2) + Math.Pow(az - bz, 2);
        return Math.Sqrt(squared);
    }
}
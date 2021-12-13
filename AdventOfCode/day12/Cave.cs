using Microsoft.VisualBasic.CompilerServices;

namespace AdventOfCode.day12; 

public class Cave {

    public const string StartCaveName = "start";
    private const string EndCaveName = "end";
    
    public string Name { get; }
    public bool Big { get; }
    public bool IsEnd { get; }
    public bool IsStart { get; }

    public IEnumerable<Cave> Neighbours => _neighbours;

    private readonly List<Cave> _neighbours = new();

    public Cave(string name) {
        Name = name;
        Big = Char.ToUpper(name[0]) == name[0];
        IsEnd = EndCaveName.Equals(name, StringComparison.Ordinal);
        IsStart = StartCaveName.Equals(name, StringComparison.Ordinal);
    }

    public void AddNeighbour(Cave neighbour) {
        _neighbours.Add(neighbour);
    }
}
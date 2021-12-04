namespace AdventOfCode.day2;
public class Command {
    public enum CommandType {
        Depth,
        Position
    }
    
    public CommandType Type { get; init; }
    public int Magnitude { get; init; }
}

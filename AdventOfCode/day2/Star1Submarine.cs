namespace AdventOfCode.day2;
public class Star1Submarine {
    public int HorizontalPosition { get; set; } = 0;
    public int Depth { get; set; } = 0;

    public void FollowCommand(Command command) {
        switch (command.Type) {
            case Command.CommandType.Depth:
                Depth += command.Magnitude;
                return;
            case Command.CommandType.Position:
                HorizontalPosition += command.Magnitude;
                return;
        }
    }
}

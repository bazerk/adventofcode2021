namespace AdventOfCode.day2;

public class Star2Submarine {
    public int HorizontalPosition { get; private set; } = 0;
    public int Depth { get; private set; } = 0;
    private int Aim { get; set; } = 0;

    public void FollowCommand(Command command) {
        switch (command.Type) {
            case Command.CommandType.Depth:
                Aim += command.Magnitude;
                return;
            case Command.CommandType.Position:
                Depth += command.Magnitude * Aim;
                HorizontalPosition += command.Magnitude;
                return;
        }
    }
}

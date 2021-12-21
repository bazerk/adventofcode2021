namespace AdventOfCode.day21; 

public class Player {
    public int Position { get; set; }
    public int Score { get; private set; }
    public bool Won => Score >= 1000;

    public bool Move(int spaces) {
        Position = (Position + spaces) % 10;
        if (Position == 0) {
            Position = 10;
        }
        Score += Position;
        return Score >= 1000;
    }

    public override string ToString() {
        return $"Pos: {Position}, Score: {Score}";
    }
}
namespace AdventOfCode.day17; 

public class Probe {
    public (int, int) Position { get; private set; } = (0, 0);
    public (int, int) Velocity { get; private set; }

    public Probe((int, int) initialVelocity) {
        Velocity = initialVelocity;
    }

    public void Move() {
        var (startX, startY) = Position;
        var (movX, movY) = Velocity;

        Position = (startX + movX, startY + movY);
        if (movX > 0) movX--;
        if (movX < 0) movX++;

        Velocity = (movX, movY - 1);
    }

    public TargetAreaTest TestTarget(TargetArea area) {
        var (x, y) = Position;
        if (area.WithinBounds(x, y)) {
            return TargetAreaTest.InArea;
        }
        var (movX, movY) = Velocity;

        var (leftX, topY) = area.TopLeftCorner;
        var (rightX, bottomY) = area.BottomRightCorner;
        
        if (x > rightX) return TargetAreaTest.OvershotX;
        if (x + movX > rightX) return TargetAreaTest.OvershotX;
        if (movX == 0 && x < leftX) return TargetAreaTest.UndershotX;
        
        if (y < bottomY) return TargetAreaTest.UndershotY;
        if (y + movY < bottomY) return TargetAreaTest.UndershotY;
        
        return TargetAreaTest.Unknown;
    }
}
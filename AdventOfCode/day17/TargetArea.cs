namespace AdventOfCode.day17; 

public class TargetArea {
    public (int, int) TopLeftCorner { get; init; }
    public (int, int) BottomRightCorner { get; init; }

    public bool WithinBounds(int x, int y) {
        var (leftX, topY) = TopLeftCorner;
        var (rightX, bottomY) = BottomRightCorner;

        if (x < leftX || x > rightX) return false;
        if (y < bottomY || y > topY) return false;

        return true;
    }
}
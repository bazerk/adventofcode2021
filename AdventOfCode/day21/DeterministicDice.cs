namespace AdventOfCode.day21; 

public class DeterministicDice {
    public int RollCount { get; private set; }

    public int Roll() {
        RollCount++;
        return RollCount;
    }
}

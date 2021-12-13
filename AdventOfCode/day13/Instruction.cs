namespace AdventOfCode.day13; 

public class Instruction {

    public enum FoldAxis {
        X,
        Y
    }
    
    public Instruction(string axis, int foldAt) {
        Axis = Enum.Parse<FoldAxis>(axis.ToUpper());
        FoldAt = foldAt;
    }
    public FoldAxis Axis { get; }
    public int FoldAt { get; }
}
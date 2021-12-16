namespace AdventOfCode.day16; 

public class Packet {
    public const int Sum = 0;
    public const int Product = 1;
    public const int Minimum = 2;
    public const int Maximum = 3;
    public const int Literal = 4;
    public const int GreaterThan = 5;
    public const int LessThan = 6;
    public const int EqualTo = 7;
    
    public int Version { get; set; }
    public int Type { get; set; }
    public List<Packet> Children { get; } = new();
    public long? LiteralValue { get; set; }

    public long GetValue() {
        switch (Type) {
            case Literal: return LiteralValue.Value;
            case Sum: return Children.Sum(ch => ch.GetValue());
            case Product: return Children.Aggregate<Packet?, long>(1, (current, child) => current * child.GetValue());
            case Minimum: return Children.Min(ch => ch.GetValue());
            case Maximum: return Children.Max(ch => ch.GetValue());
            case GreaterThan: {
                if (Children[0].GetValue() > Children[1].GetValue()) {
                    return 1;
                }

                return 0;
            }
            case LessThan: {
                    if (Children[0].GetValue() < Children[1].GetValue()) {
                        return 1;
                    }

                    return 0;
            }
            case EqualTo: {
                if (Children[0].GetValue() == Children[1].GetValue()) {
                    return 1;
                }

                return 0;
            }
        }

        throw new NotImplementedException();
    }
}
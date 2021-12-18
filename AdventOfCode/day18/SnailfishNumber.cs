namespace AdventOfCode.day18; 

public class SnailfishNumber {
    public object LeftValue { get; private set; }
    public object RightValue { get; private set; }
    public SnailfishNumber? Parent { get; set; }

    public SnailfishNumber(object left, object right, SnailfishNumber? parent = null) {
        LeftValue = left;
        RightValue = right;
        Parent = parent;

        if (left is SnailfishNumber lsn) {
            lsn.Parent = this;
        }

        if (right is SnailfishNumber rsn) {
            rsn.Parent = this;
        }
    }
    
    public static SnailfishNumber Add(SnailfishNumber a, SnailfishNumber b) {
        return new SnailfishNumber(a, b);
    }

    public void Reduce() {
        var stable = false;
        while (!stable) {
            var exploded = ExplodeIfNeeded();
            if (exploded) {
                continue;
            }

            var split = SplitIfNeeded();
            if (split) {
                continue;
            }

            stable = true;
        }
    }

    public int GetNestingLevel() {
        var level = 0;
        var parent = Parent;
        while (parent != null) {
            level++;
            parent = parent.Parent;
        }

        return level;
    }

    private bool ExplodeIfNeeded() {
        var nestingLevel = GetNestingLevel();
        if (nestingLevel >= 4) {
            Parent.DealWithExplosion(this, (int) LeftValue, (int) RightValue);
            return true;
        }
        if (LeftValue is SnailfishNumber left && left.ExplodeIfNeeded()) {
            return true;
        }
        if (RightValue is SnailfishNumber right && right.ExplodeIfNeeded()) {
            return true;
        }
        return false;
    }

    private void DealWithExplosion(SnailfishNumber child, int leftValue, int rightValue) {
        if (child == LeftValue) {
            LeftValue = 0;
            ShiftLeftUp(leftValue);
            ShiftRightDown(rightValue, true);
            return;
        }
        if (child == RightValue) {
            RightValue = 0;
            ShiftRightUp(rightValue);
            ShiftLeftDown(leftValue, true);
        }
    }

    private void ShiftRightUp(int value) {
        if (Parent is null) {
            return;
        }

        if (Parent.RightValue == this) {
            Parent.ShiftRightUp(value);
        }

        if (Parent.LeftValue == this) {
            Parent.ShiftRightDown(value, fromLeftChild: true);
        }
    }

    private void ShiftLeftUp(int value) {
        if (Parent is null) {
            return;
        }

        if (Parent.LeftValue == this) {
            Parent.ShiftLeftUp(value);
        }

        if (Parent.RightValue == this) {
            Parent.ShiftLeftDown(value, fromRightChild: true);
        }
    }

    private void ShiftLeftDown(int value, bool fromRightChild=false) {
        if (fromRightChild) {
            if (LeftValue is int lval) {
                LeftValue = lval + value;
                return;
            }
            ((SnailfishNumber)LeftValue).ShiftLeftDown(value);
            return;
        }
        
        if (RightValue is int rval) {
            RightValue = rval + value;
            return;
        }
        ((SnailfishNumber)RightValue).ShiftLeftDown(value);
    }

    private void ShiftRightDown(int value, bool fromLeftChild=false) {
        if (fromLeftChild) {
            if (RightValue is int rval) {
                RightValue = rval + value;
                return;
            }
            ((SnailfishNumber)RightValue).ShiftRightDown(value);
            return;
        }

        if (LeftValue is int lval) {
            LeftValue = lval + value;
            return;
        }
        
        ((SnailfishNumber)LeftValue).ShiftRightDown(value);
    }

    private SnailfishNumber CreateFromSplit(int value) {
        var lv = value / 2;
        var rv = value / 2;
        if ((value % 2) != 0) {
            rv++;
        }

        return new SnailfishNumber(lv, rv, this);
    }

    private bool SplitIfNeeded() {
        if (LeftValue is SnailfishNumber left && left.SplitIfNeeded()) {
            return true;
        }
        if (LeftValue is int lv and >= 10) {
            LeftValue = CreateFromSplit(lv);
            return true;
        }        
        if (RightValue is SnailfishNumber right && right.SplitIfNeeded()) {
            return true;
        }
        if (RightValue is int rv and >= 10) {
            RightValue = CreateFromSplit(rv);
            return true;
        }
        
        return false;
    }

    public int GetMagnitude() {
        int lv;
        if (LeftValue is SnailfishNumber left) {
            lv = left.GetMagnitude();
        }
        else {
            lv = (int) LeftValue;
        }

        int rv;
        if (RightValue is SnailfishNumber right) {
            rv = right.GetMagnitude();
        }
        else {
            rv = (int) RightValue;
        }

        return lv * 3 + rv * 2;
    }
    
    public override string ToString() {
        return $"[{LeftValue},{RightValue}]";
    }
}
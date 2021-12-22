namespace AdventOfCode.day22; 

public class Cuboid {
    public (int, int) X { get; init; }
    public (int, int) Y { get; init; }
    public (int, int) Z { get; init; }

    public long GetVolume() {
        var (x1, x2) = X;
        var (y1, y2) = Y;
        var (z1, z2) = Z;

        return (long)(x2 - x1 + 1) * (y2 - y1 + 1) * (z2 - z1 + 1);
    }

    // Return this cuboid broken up into sub cuboids and any remainder from the input cuboid
    // This is just remove in reverse - we can remove the existing cuboid from the input cuboid and return the
    // remainder
    public IEnumerable<Cuboid> Intersect(Cuboid cuboid) {
        return cuboid.Remove(this);
    }
    
    // Return any sub cuboids left over after potentially removing a space
    public IEnumerable<Cuboid> Remove(Cuboid toRemove) {
        if (!Intersects(toRemove)) {
            yield return this;
            yield break;
        }
        if (toRemove.Contains(this)) yield break;
        
        // We need to split on the left edge of X
        if (toRemove.X.Item1 > X.Item1 && toRemove.X.Item1 <= X.Item2) {
            var s1 = new Cuboid {
                X = (X.Item1, toRemove.X.Item1-1),
                Y = Y,
                Z = Z
            };
            yield return s1;
            var s2 = new Cuboid {
                X = (toRemove.X.Item1, X.Item2),
                Y = Y,
                Z = Z
            };
            foreach (var c in s2.Remove(toRemove)) {
                yield return c;
            }
            yield break;
        }
        
        // We need to split on the right edge of X
        if (toRemove.X.Item2 < X.Item2 && toRemove.X.Item2 >= X.Item1) {
            var s1 = new Cuboid {
                X = (toRemove.X.Item2 + 1, X.Item2),
                Y = Y,
                Z = Z
            };
            yield return s1;
            var s2 = new Cuboid {
                X = (X.Item1, toRemove.X.Item2),
                Y = Y,
                Z = Z
            };
            foreach (var c in s2.Remove(toRemove)) {
                yield return c;
            }
            yield break;
        }
        
        // We need to split on the bottom edge of Y
        if (toRemove.Y.Item1 > Y.Item1 && toRemove.Y.Item1 <= Y.Item2) {
            var s1 = new Cuboid {
                X = X,
                Y = (Y.Item1, toRemove.Y.Item1-1),
                Z = Z
            };
            yield return s1;
            var s2 = new Cuboid {
                X = X,
                Y = (toRemove.Y.Item1, Y.Item2),
                Z = Z
            };
            foreach (var c in s2.Remove(toRemove)) {
                yield return c;
            }
            yield break;
        }
        
        // We need to split on the top edge of Y
        if (toRemove.Y.Item2 < Y.Item2 && toRemove.Y.Item2 >= Y.Item1) {
            var s1 = new Cuboid {
                X = X,
                Y = (toRemove.Y.Item2 + 1, Y.Item2),
                Z = Z
            };
            yield return s1;
            var s2 = new Cuboid {
                X = X,
                Y = (Y.Item1, toRemove.Y.Item2),
                Z = Z
            };
            foreach (var c in s2.Remove(toRemove)) {
                yield return c;
            }
            yield break;
        }

        // We need to split on the far edge of Z
        if (toRemove.Z.Item1 > Z.Item1 && toRemove.Z.Item1 <= Z.Item2) {
            var s1 = new Cuboid {
                X = X,
                Y = Y,
                Z = (Z.Item1, toRemove.Z.Item1-1),
            };
            yield return s1;
            var s2 = new Cuboid {
                X = X,
                Y = Y,
                Z = (toRemove.Z.Item1, Z.Item2),
            };
            foreach (var c in s2.Remove(toRemove)) {
                yield return c;
            }
            yield break;
        }
        
        // We need to split on the near edge of Z
        if (toRemove.Z.Item2 < Z.Item2 && toRemove.Z.Item2 >= Z.Item1) {
            var s1 = new Cuboid {
                X = X,
                Z = (toRemove.Z.Item2 + 1, Z.Item2),
                Y = Y,
            };
            yield return s1;
            var s2 = new Cuboid {
                X = X,
                Y = Y,
                Z = (Z.Item1, toRemove.Z.Item2),
            };
            foreach (var c in s2.Remove(toRemove)) {
                yield return c;
            }
            yield break;
        }   
    }

    public bool Contains(Cuboid cuboid) {
        var (x1, x2) = X;
        var (y1, y2) = Y;
        var (z1, z2) = Z;

        return x1 <= cuboid.X.Item1 && x2 >= cuboid.X.Item2 &&
               y1 <= cuboid.Y.Item1 && y2 >= cuboid.Y.Item2 &&
               z1 <= cuboid.Z.Item1 && z2 >= cuboid.Z.Item2;
    }

    public bool Intersects(Cuboid cuboid) {
        var (x1, x2) = X;
        var (y1, y2) = Y;
        var (z1, z2) = Z;

        if (cuboid.X.Item2 < x1) return false;
        if (cuboid.X.Item1 > x2) return false;
        if (cuboid.Y.Item2 < y1) return false;
        if (cuboid.Y.Item1 > y2) return false;
        if (cuboid.Z.Item2 < z1) return false;
        if (cuboid.Z.Item1 > z2) return false;

        return true;
    }

    public override string ToString() {
        return $"x={X.Item1}..{X.Item2}, {Y.Item1}..{Y.Item2}, {Z.Item1}..{Z.Item2}";
    }
}
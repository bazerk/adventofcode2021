namespace AdventOfCode.day7; 

public static class Solver {

    private static (int, int, List<int>) GetInitialPositions(string filename) {
        var split = File.ReadAllText(filename).Split(',');
        var initialPositions = new List<int>(split.Length);
        var minPos = int.MaxValue;
        var maxPos = int.MinValue;

        foreach (var posStr in split) {
            var position = int.Parse(posStr);
            initialPositions.Add(position);
            if (position < minPos) minPos = position;
            if (position > maxPos) maxPos = position;
        }

        return (minPos, maxPos, initialPositions);
    }
    
    private static int Solve(string filename, Func<int, int> fuelCostFunc) {
        var (min, max,initialPositions) = GetInitialPositions(filename);
        var minFuelConsumption = int.MaxValue;
        for (var testPosition = min; testPosition <= max; testPosition++) {
            var fuelConsumption = 0;
            foreach (var crabPosition in initialPositions) {
                fuelConsumption += fuelCostFunc(Math.Abs(crabPosition - testPosition));
                if (fuelConsumption >= minFuelConsumption) break;
            }

            if (fuelConsumption < minFuelConsumption) {
                minFuelConsumption = fuelConsumption;
            }
        }
        
        return minFuelConsumption;
    }

    public static int SolveStar1(string filename = "day7/input1.txt") {
        return Solve(filename, (val) => val);
    }

    public static int SolveStar2(string filename = "day7/input1.txt") {
        int FuelCost(int moved) {
            return Enumerable.Range(1, moved).Sum();
        };
        
        return Solve(filename, FuelCost);
    }
}
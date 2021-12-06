namespace AdventOfCode.day6; 

public static class Solver {
    private const int MaxTimerVal = 8;

    private static LinkedList<LanternFish> GetInitialFish(string filename) {
        var text = File.ReadAllText(filename);
        return new LinkedList<LanternFish>(
            text.Split(',').Select(t => new LanternFish(int.Parse(t)))
        );
    }
    
    public static int SolveStar1(string filename = "day6/input1.txt", int simulationDays = 80) {
        var allFish = GetInitialFish(filename);
        for (var day = 0; day < simulationDays; day++) {
            var fishNode = allFish.First;
            while (fishNode != null) {
                var baby = fishNode.Value.Tick();
                if (baby != null) {
                    allFish.AddFirst(baby);
                }

                fishNode = fishNode.Next;
            }
        }
        
        return allFish.Count;    
    }
    
    public static long SolveStar2(string filename = "day6/input1.txt", int simulationDays = 256) {
        // Need to compress the fish into fish groups
        var text = File.ReadAllText(filename);
        var fish = new long[MaxTimerVal + 1];
        foreach (var timer in text.Split(',').Select(long.Parse)) {
            fish[timer] += 1;
        }

        for (var day = 0; day < simulationDays; day++) {
            var newFish = new long[MaxTimerVal + 1];
            for (var timerVal = 0; timerVal <= MaxTimerVal; timerVal++) {
                var fishCount = fish[timerVal];
                if (timerVal == 0) {
                    newFish[6] += fishCount;
                    newFish[8] += fishCount;
                } else {
                    newFish[timerVal - 1] += fishCount;
                }
            }

            fish = newFish;
        }

        return fish.Sum();
    }
}
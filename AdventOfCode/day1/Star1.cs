using System.IO;

namespace AdventOfCode.day1 {
    public static class Star1 {
        public static int Solve() {
            var lines = File.ReadAllLines("day1/input1.txt");
            int? current = null;
            var increaseCount = 0;
            foreach (var line in lines) {
                var val = int.Parse(line);
                if (current == null) {
                    current = val;
                    continue;
                }
    
                if (val > current) {
                    increaseCount++;
                }
                current = val;
            }

            return increaseCount;
        }        
    }
}
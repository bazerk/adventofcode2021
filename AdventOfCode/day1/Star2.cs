using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.day1 {
    public static class Star2 {
        private static IEnumerable<int> GetValues() {
            var lines = File.ReadAllLines("day1/input1.txt");
            var numbers = lines.Select(int.Parse).ToArray();

            for (int ix = 0; ix < numbers.Length - 2; ix++) {
                yield return numbers[ix] + numbers[ix + 1] + numbers[ix + 2];
            }
        }

        public static int Solve() {
            
            int? current = null;
            var increaseCount = 0;
            foreach (var val in GetValues()) {
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
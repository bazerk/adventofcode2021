namespace AdventOfCode.day6; 

public class LanternFish {
    private int Timer { get; set; }

    public LanternFish(int timer) {
        Timer = timer;
    }

    public LanternFish? Tick() {
        if (Timer == 0) {
            Timer = 6;
            return new LanternFish(8);
        }

        Timer -= 1;
        return null;
    }
}
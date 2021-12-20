namespace AdventOfCode.day20; 

public static class Solver {
    public static (ImageEnhancer, Image) GetImage(string filename) {
        var data = File.ReadAllLines(filename);
        var enhancer = new ImageEnhancer(data[0]);
        var image = new Image(data.Skip(2).ToArray(), false);
        return (enhancer, image);
    }
    
    public static int SolveStar1(string filename = "day20/input1.txt") {
        var (enhancer, image) = Solver.GetImage(filename);
        var i2 = enhancer.Enhance(image);
        var i3 = enhancer.Enhance(i2);
        return i3.GetLitCount();
    }
    
    public static int SolveStar2(string filename = "day20/input1.txt") {
        var (enhancer, image) = Solver.GetImage(filename);
        for (var ix = 0; ix < 50; ix++) {
            image = enhancer.Enhance(image);
        }
        return image.GetLitCount();
    }
}
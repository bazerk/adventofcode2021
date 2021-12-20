using System.Text;

namespace AdventOfCode.day20; 

public class Image {
    public int Width => Pixels.GetLength(0);
    public int Height => Pixels.GetLength(1);
    public bool[,] Pixels { get; }
    public bool UnknownLit { get; }
    

    public Image(string[] lines, bool unknownLit) {
        UnknownLit = unknownLit;
        Pixels = new bool[lines[0].Length, lines.Length];
        var y = 0;
        foreach (var line in lines) {
            var x = 0;
            foreach (var val in line) {
                Pixels[x, y] = val == '#';
                x++;
            }
            y++;
        }
    }

    public Image(bool[,] pixels, bool unknownLit) {
        UnknownLit = unknownLit;
        Pixels = pixels;
    }

    public IEnumerable<(int, int)> GetLitPixels() {
        for (var y = 0; y < Height; y++) {
            for (var x = 0; x < Width; x++) {
                if (Pixels[x, y]) {
                    yield return (x, y);
                }
            }
        }
    }

    public int GetLitCount() {
        return GetLitPixels().Count();
    }
    
    public override string ToString() {
        var sb = new StringBuilder((Width + 1) * Height);
        for (var y = 0; y < Height; y++) {
            for (var x = 0; x < Width; x++) {
                sb.Append(Pixels[x, y] ? '#' : '.');
            }
            sb.Append(Environment.NewLine);
        }
        return sb.ToString();
    }
}
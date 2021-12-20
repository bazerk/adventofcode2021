using System.Runtime.InteropServices;

namespace AdventOfCode.day20; 

public class ImageEnhancer {
    private readonly Dictionary<int, bool> _enhancementData = new();

    public ImageEnhancer(string algoData) {
        for (var ix = 0; ix < algoData.Length; ix++) {
            _enhancementData[ix] = algoData[ix] == '#';
        }
    }

    private bool GetValue(int posX, int posY, Image image) {
        var binaryString = "";
        for (var y = posY-1; y <= posY + 1; y++) {
            for (var x = posX-1; x <= posX + 1; x++) {
                if (x < 0 || x >= image.Width || y < 0 || y >= image.Height) {
                    binaryString += image.UnknownLit ? "1" : "0";
                    continue;
                }

                binaryString += image.Pixels[x, y] ? "1" : "0";
            }   
        }

        var value = Convert.ToInt32(binaryString, 2);
        return _enhancementData[value];
    }

    public bool TestVal(int val) => _enhancementData[val];
    
    public Image Enhance(Image input) {
        var newData = new bool[input.Width + 2, input.Height + 2];
        for (var x = -1; x < input.Width + 1; x++) {
            for (var y = -1; y < input.Height + 1; y++) {
                newData[x + 1, y + 1] = GetValue(x, y, input);
            }
        }

        var unknownLit = input.UnknownLit;
        if (_enhancementData[0] && !_enhancementData[511]) {
            unknownLit = !input.UnknownLit;
        }
        return new Image(newData, unknownLit);
    }
}
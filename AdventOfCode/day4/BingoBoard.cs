namespace AdventOfCode.day4; 

public class BingoBoard {
    public const int GridSize = 5;
    private readonly BingoSquare[,] _squares;
    private readonly Dictionary<int, BingoSquare> _squaresByNumber = new();

    public BingoBoard(IEnumerable<IEnumerable<int>> lines) {
        var ixRow = 0;
        _squares = new BingoSquare[GridSize, GridSize];
        foreach (var line in lines) {
            var ixCol = 0;
            foreach (var number in line) {
                var square = new BingoSquare {
                    Number = number,
                    Row = ixRow,
                    Col = ixCol,
                };
                _squaresByNumber[number] = square;
                _squares[ixRow, ixCol] = square;
                ixCol++;
            }

            ixRow++;
        }
    }

    public bool PlayNumber(int number) {
        if (!_squaresByNumber.TryGetValue(number, out var square)) {
            return false;
        }

        square.Marked = true;
        if (TestRow(square.Row) || TestCol(square.Col)) {
            return true;
        }

        return false;
    }

    private bool TestRow(int row) {
        for (var ix = 0; ix < GridSize; ix++) {
            if (!_squares[row, ix].Marked) {
                return false;
            }
        }

        return true;
    }

    private bool TestCol(int col) {
        for (var ix = 0; ix < GridSize; ix++) {
            if (!_squares[ix, col].Marked) {
                return false;
            }
        }

        return true;
    }

    public int GetUnmarkedValue() {
        return _squaresByNumber.Values.Where(sq => !sq.Marked).Sum(sq => sq.Number);
    }
}

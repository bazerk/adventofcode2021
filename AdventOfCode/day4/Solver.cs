namespace AdventOfCode.day4; 

public static class Solver {

    private static (IEnumerable<int>, List<BingoBoard>) GetBoardsAndNumbers (string fileName) {
        var inputData = File.ReadAllLines(fileName).ToList();
        var numbers = inputData[0].Split(',').Select(int.Parse);
        var boards = new List<BingoBoard>();
        for (var ix = 2; ix < inputData.Count; ix += BingoBoard.GridSize + 1) {
            var lines = new List<IEnumerable<int>>();
            for (var row = 0; row < BingoBoard.GridSize; row++) {
                lines.Add(inputData[ix + row].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            }
            boards.Add(new BingoBoard(lines));
        }
        
        return (numbers, boards);
    }
    
    public static int SolveStar1(string filename = "day4/input1.txt") {
        var (numbers, boards) = GetBoardsAndNumbers(filename);
        foreach (var number in numbers) {
            foreach (var board in boards) {
                if (board.PlayNumber(number)) {
                    return number * board.GetUnmarkedValue();
                }
            }
        }
        return -1;
    }
 
    public static int SolveStar2(string filename = "day4/input1.txt") {
        var (numbers, boards) = GetBoardsAndNumbers(filename);
        foreach (var number in numbers) {
            var boardsInPlay = new List<BingoBoard>();
            foreach (var board in boards) {
                if (!board.PlayNumber(number)) {
                    boardsInPlay.Add(board);
                }
            }

            if (boardsInPlay.Count == 0) {
                var losingBoard = boards.Last();
                return number * losingBoard.GetUnmarkedValue();
            }

            boards = boardsInPlay;
        }
        return -1;
    }
}
namespace AdventOfCode2022.Day2;

public class Day2 : IAdventOfCodeDay
{
    //MATCH MATRIX
    //   X Y Z
    // A 3 6 0 
    // B 0 3 6
    // C 6 0 3
    private readonly int[][] _matchMatrix = 
    {
        new[] {3, 6, 0},
        new[] {0, 3, 6},
        new[] {6, 0, 3},
    };
    
    public async Task ExecuteAsync()
    {
        //PART 1
        var result = 0;
        
        await foreach (var line in File.ReadLinesAsync("./Day2/day2.txt"))
        {
            var split = line.Split(" ");
            var opponentIndex = GetIndex(split.First());
            var mineIndex = GetIndex(split.Last());
            result += mineIndex + 1 + _matchMatrix[opponentIndex][mineIndex];
        }

        Console.WriteLine(result);

        int GetIndex(string move)
            => move switch
            {
                "A" or "X" => 0,
                "B" or "Y" => 1,
                "C" or "Z" => 2
            };
        
        // PART 2
        result = 0;
        
        await foreach (var line in File.ReadLinesAsync("./Day2/day2.txt"))
        {
            var split = line.Split(" ");
            var opponentMove = TransformToDigit(split.First());
            var expectedResult = TransformToDigit(split.Last());
            var marchPoint = GetMatchPoint(opponentMove, expectedResult);

            result += expectedResult + marchPoint;
        }

        Console.WriteLine(result);
        
        int TransformToDigit(string value)
         => value switch 
         {
             "A" => 1,
             "B" => 2, 
             "C" => 3,
             "X" => 0,
             "Y" => 3,
             "Z" => 6,
        };

        int GetMatchPoint(int opponentMove, int result)
            => result switch
            {
                0 => opponentMove is 1 ? 3 : (opponentMove + 2) % 3,
                3 => opponentMove,
                6 => (opponentMove % 3) + 1
            };
    }
}
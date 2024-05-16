public class Planet
{
    private char[,] map;

    public Planet(char[,] initialMap)
    {
        map = initialMap;
    }

    public char GetSymbolAtPosition(int x, int y)
    {
        if (IsValidPosition(x, y))
        {
            return map[y, x];
        }
        return '#'; // Treat out-of-bounds as an obstacle
    }

    public void SetSymbolAtPosition(int x, int y, char symbol)
    {
        if (IsValidPosition(x, y))
        {
            map[y, x] = symbol;
        }
    }

    public char[,] GetMap()
    {
        return map;
    }

    public void PrintMap()
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < map.GetLength(1) && y >= 0 && y < map.GetLength(0);
    }
}
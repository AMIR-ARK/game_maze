using System;

class MazeGame
{
    private static int[,] maze;
    private static int mazeWidth = 50;
    private static int mazeHeight = 50;
    private static int startRow = 0;
    private static int startCol = 0;
    private static int endRow = 49;
    private static int endCol = 49;
    private static Random random = new Random();

    static void Main(string[] args)
    {
        // Create the maze
        GenerateMaze();

        // Print the maze
        PrintMaze();

        // Play the game
        PlayGame();
    }

    static void GenerateMaze()
    {
        // Initialize the maze with all walls
        maze = new int[mazeWidth, mazeHeight];
        for (int i = 0; i < mazeWidth; i++)
        {
            for (int j = 0; j < mazeHeight; j++)
            {
                maze[i, j] = 1;
            }
        }

        // Create random openings in the maze
        for (int i = 0; i < mazeWidth; i++)
        {
            maze[i, 0] = 0;
            maze[i, mazeHeight - 1] = 0;
        }
        for (int j = 0; j < mazeHeight; j++)
        {
            maze[0, j] = 0;
            maze[mazeWidth - 1, j] = 0;
        }

        // Create random walls in the maze
        for (int i = 0; i < mazeWidth * 4; i++)
        {
            int row = random.Next(1, mazeWidth - 1);
            int col = random.Next(1, mazeHeight - 1);
            maze[row, col] = 1;
        }
    }

    static void PrintMaze()
    {
        for (int j = 0; j < mazeHeight; j++)
        {
            for (int i = 0; i < mazeWidth; i++)
            {
                if (i == startCol && j == startRow)
                {
                    Console.Write("S ");
                }
                else if (i == endCol && j == endRow)
                {
                    Console.Write("E ");
                }
                else if (maze[i, j] == 1)
                {
                    Console.Write("# ");
                }
                else
                {
                    Console.Write(". ");
                }
            }
            Console.WriteLine();
        }
    }

    static void PlayGame()
    {
        int currentRow = startRow;
        int currentCol = startCol;
        while (currentRow != endRow || currentCol != endCol)
        {
            Console.Write("Enter a direction (up, down, left, right): ");
            string direction = Console.ReadLine();

            int newRow = currentRow;
            int newCol = currentCol;
            switch (direction)
            {
                case "up":
                    newRow--;
                    break;
                case "down":
                    newRow++;
                    break;
                case "left":
                    newCol--;
                    break;
                case "right":
                    newCol++;
                    break;
                default:
                    Console.WriteLine("Invalid direction.");
                    continue;
            }

            if (newRow < 0 || newRow >= mazeHeight || newCol < 0 || newCol >= mazeWidth)
            {
                Console.WriteLine("You hit a wall.");
            }
            else if (maze[newCol, newRow] == 1)
            {
                Console.WriteLine("You hit a wall.");
            }
            else
            {
                currentRow = newRow;
                currentCol = newCol;
            }
        }

        Console.WriteLine("Congratulations, you made it to the end!");
    }
}
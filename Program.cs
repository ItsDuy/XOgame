using System.Drawing;

namespace XOGame;

class Program
{
    static int n = 15;
    static string[,] Caro_Table = new string[n, n];
    static int player = 1;
    static int pos_x;
    static int pos_y;
    static void Main(string[] arg)
    {

        InitCaroTable();
       
        DrawCaroTable();
        PlayGame();


    }
    static void InitCaroTable()
    {


        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (row == 0)
                {
                    if (col < 10)
                    {

                        Caro_Table[row, col] = $"  {col}";
                    }
                    else
                    {
                        Caro_Table[row, col] = $" {col}";
                    }
                }
                else if (col == 0)
                {
                    if (row < 10)
                    {
                        Caro_Table[row, col] = $"  {row}";
                    }
                    else
                    {
                        Caro_Table[row, col] = $" {row}";
                    }

                }
                else
                {
                    Caro_Table[row, col] = " - ";
                }
            }
        }
    }
    static void DrawCaroTable()
    {
        Console.Clear();
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {


                if (Caro_Table[row, col] == "X" || Caro_Table[row, col] == "O")
                {
                    if (Caro_Table[row, col] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($" {Caro_Table[row, col]} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($" {Caro_Table[row, col]} ");
                        Console.ResetColor();
                    }

                }
                else if (row == 0 || col == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{Caro_Table[row, col]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{Caro_Table[row, col]}");
                }
            }
            Console.WriteLine();
        }
    }
    static void PlayGame()
    {
        while (true)
        {

            do
            {
                Console.WriteLine($"{(player == 1 ? "Luot choi cua player 1" : "Luot choi cua player 2 ")}");
                Console.WriteLine($"X:");
                int.TryParse(Console.ReadLine(), out pos_x);
                Console.WriteLine($"Y:");
                int.TryParse(Console.ReadLine(), out pos_y);
            }
            while (!Validpos());
            if (Validpos())
            {
                if (player == 1)
                {
                    Caro_Table[pos_x, pos_y] = "X";

                    DrawCaroTable();
                    CheckWin();
                    player = 2;
                }
                else if (player == 2)
                {
                    Caro_Table[pos_x, pos_y] = "O";

                    DrawCaroTable();
                    CheckWin();
                    player = 1;
                }
            }
        }
    }
    static bool Validpos()
    {
        if (pos_x <=0 || pos_x >= n || pos_y <= 0 || pos_y >= n || Caro_Table[pos_x, pos_y] == "X" || Caro_Table[pos_x, pos_y] == "O")
        {
            return false;
        }
        else return true;
    }
    
    static void CheckWin()
    {
        //Check horizontal
        int count=0;
        for (int i = 1; i < n; i++)
        {
            if (Caro_Table[pos_x, i] == Caro_Table[pos_x, pos_y])
            {
                count++;
            }
            else
            {
                count = 0;
            }
            if (count == 5)
            {
                Console.WriteLine($"Player {player} win!");
                return;
            }
        }
        //Check vertical 
        count=0;
        for (int j = 1; j < n; j++)
        {
            if (Caro_Table[j, pos_y] == Caro_Table[pos_x, pos_y])
            {
                count++;
            }
            else
            {
                count = 0;
            }
            if (count == 5)
            {
                Console.WriteLine($"Player {player} win!");
                return;
            }
        }
        //Check diagonal
        count=0;
        for (int i = 0; i < n; i++)
        {
            int x = pos_x + i;
            int y = pos_y + i;
            if (x < n && y < n && Caro_Table[x, y] == Caro_Table[pos_x, pos_y])
            {
                if (++count == 5)
                {
                    Console.WriteLine($"Player {Caro_Table[pos_x, pos_y]} wins!");
                    return;
                }
            }
            else break; // Break out of loop if no match
        }
        count=0;
        for (int i = 0; i < n; i++)
        {
            int x = pos_x + i;
            int y = pos_y - i;
            if (x < n && y >= 0 && Caro_Table[x, y] == Caro_Table[pos_x, pos_y])
            {
                if (++count == 5)
                {
                    Console.WriteLine($"Player {Caro_Table[pos_x, pos_y]} wins!");
                    return;
                }
            }
            else break; // Break out of loop if no match
        }
    }

}

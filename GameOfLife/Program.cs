using GameOfLife.Classes;

var board = new Board();

for (;;)
{
    board.Step();
    
    Console.WriteLine("Press any key to step...");
    Console.ReadKey();
}


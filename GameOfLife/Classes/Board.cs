using System.Drawing;

namespace GameOfLife.Classes;

public class Board : IBoard
{
    private readonly int _rows;
    private readonly int _columns;
    public List<Cell> Cells { get; set; }

    public Board(int rows = 10, int columns = 10)
    {
        _rows = rows;
        _columns = columns;
        
        Cells = new List<Cell>();
        var random = new Random();

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < columns; col++)
            {
                var tempCell = new Cell(this, new Point(col, row))
                {
                    CurrentState = random.Next(2) == 1 ? State.Alive : State.Dead
                };

                Cells.Add(tempCell);
            }
        }
    }

    public List<Cell> GetNeighbours(Point currentLocation) => Cells.Where(cell =>
            Math.Abs(cell.Location.X - currentLocation.X) <= 1 || Math.Abs(cell.Location.Y - currentLocation.Y) <= 1)
        .ToList();

    public void DrawStep()
    {
        for (var row = 0; row < _rows; row++)
        {
            for (var col = 0; col < _columns; col++)
            {
                var focusedCell = Cells.Single(cell => cell.Location.X == col && cell.Location.Y == row).CurrentState;

                Console.Write(focusedCell == State.Alive ? "O " : ". ");
            }
            Console.WriteLine();
        }
    }
    
    public void CleanUp() => Cells.RemoveAll(cell => cell.CurrentState == State.Dead);
}
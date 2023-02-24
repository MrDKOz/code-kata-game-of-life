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
                var initialState = random.Next(2) == 1 ? State.Alive : State.Dead;
                var tempCell = new Cell(this, new Point(col, row), initialState);

                Cells.Add(tempCell);
            }
        }
    }

    public List<Cell> GetNeighbours(Point currentLocation)
    {
        var neighbours = new List<Cell>();

        foreach (var cell in Cells)
        {
            if (cell.Location != currentLocation)
            {
                if (Math.Abs(cell.Location.X - currentLocation.X) <= 1 &&
                    Math.Abs(cell.Location.Y - currentLocation.Y) <= 1)
                {
                    neighbours.Add(cell);
                }
            }
        }

        return neighbours;
    }

    public void Step()
    {
        foreach (var cell in Cells)
        {
            cell.CalculateNext();
        }

        foreach (var cell in Cells)
        {
            cell.ApplyNext();
        }

        DrawStep();
    }
    
    private void DrawStep()
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
}
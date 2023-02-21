using System.Drawing;

namespace GameOfLife.Classes;

public class Board : IBoard
{
    public List<Cell> Cells { get; set; }

    public List<Cell> GetNeighbours(Point currentLocation) => Cells.Where(cell =>
            Math.Abs(cell.Location.X - currentLocation.X) <= 1 || Math.Abs(cell.Location.Y - currentLocation.Y) <= 1)
        .ToList();

    public void CleanUp() => Cells.RemoveAll(cell => cell.State == State.DEAD);
}
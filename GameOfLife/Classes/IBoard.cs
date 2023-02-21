using System.Drawing;

namespace GameOfLife.Classes;

public interface IBoard
{
    public List<Cell> GetNeighbours(Point currentLocation);
}
using System.Data.Common;
using System.Drawing;

namespace GameOfLife.Classes;

public class Cell
{
    private readonly IBoard _board;
    public Point Location { get; set; }
    public State State { get; set; }
    private State NextState { get; set; }
    
    private List<Cell> Neighbours => _board.GetNeighbours(Location);

    public Cell(IBoard board)
    {
        _board = board;
    }

    // Calculate without changing current state
    public void CalculateNext()
    {
        var aliveNeighbours = Neighbours.Count(cell => cell.State == State.ALIVE);

        switch (aliveNeighbours)
        {
            case <2:
            case >3:
                NextState = State.DEAD;
                break;
            case 2:
            case 3:
                NextState = State.ALIVE;
                break;
        }
    }

    // Apply the pre-calculated state.
    public void ApplyNext() => State = NextState;
}

public enum State
{
    ALIVE,
    DEAD
}
using System.Drawing;

namespace GameOfLife.Classes;

public class Cell
{
    private readonly IBoard _board;
    public Point Location { get; set; }
    public State State { get; set; }
    private State NextState { get; set; }
    
    private IEnumerable<Cell> Neighbours => _board.GetNeighbours(Location);

    public Cell(IBoard board)
    {
        _board = board;
    }

    // Calculate without changing current state
    public void CalculateNext()
    {
        var aliveNeighbours = Neighbours.Count(cell => cell.State == State.Alive);

        switch (aliveNeighbours)
        {
            case <2:
            case >3:
                NextState = State.Dead;
                break;
            case 2:
            case 3:
                NextState = State.Alive;
                break;
        }
    }

    // Apply the pre-calculated state.
    public void ApplyNext() => State = NextState;
}

public enum State
{
    Alive,
    Dead
}
using System.Drawing;

namespace GameOfLife.Classes;

public class Cell
{
    private readonly IBoard _board;
    public Point Location { get; set; }
    public State CurrentState { get; set; }
    private State NextState { get; set; }
    
    private IEnumerable<Cell> Neighbours => _board.GetNeighbours(Location);

    public Cell(IBoard board, Point location, State initialState = State.Dead)
    {
        Location = location;
        _board = board;
        CurrentState = initialState;
    }

    // Calculate without changing current state
    public void CalculateNext()
    {
        NextState = CurrentState;

        var aliveNeighbours = Neighbours.Count(cell => cell.CurrentState == State.Alive);
        
        if (CurrentState == State.Alive)
        {
            if (aliveNeighbours is < 2 or > 3)
            {
                NextState = State.Dead;
            }
        }
        else
        {
            if (aliveNeighbours == 3)
            {
                NextState = State.Alive;
            }
        }
    }

    // Apply the pre-calculated state.
    public void ApplyNext() => CurrentState = NextState;
}

public enum State
{
    Alive,
    Dead
}
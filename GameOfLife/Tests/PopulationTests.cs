using System.Drawing;
using GameOfLife.Classes;
using NUnit.Framework;

namespace GameOfLife.Tests;

public class PopulationTests
{
    [Test]
    public void CheckOverpopulationRule()
    {
        var board = new Board();
        var focusCell = new Cell(board, new Point(3, 3), State.Alive);

        board.Cells = new List<Cell>
        {
            focusCell,
            new(board, new Point(3, 2), State.Alive),
            new(board, new Point(2, 2), State.Alive),
            new(board, new Point(2, 3), State.Alive),
            new(board, new Point(2, 4), State.Alive)
        };

        focusCell.CalculateNext();
        focusCell.ApplyNext();

        Assert.That(focusCell.CurrentState == State.Dead);
    }
}
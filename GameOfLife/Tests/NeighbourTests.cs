using System.Drawing;
using GameOfLife.Classes;
using NUnit.Framework;

namespace GameOfLife.Tests;

public class NeighbourTests
{
    [Test]
    public void GetSingleNeighbour()
    {
        var board = new Board();
        board.Cells = new List<Cell>
        {
            new(board, new Point(5, 5))
        };

        var neighbours = board.GetNeighbours(new Point(4, 4));

        Assert.That(neighbours.Count == 1);
    }

    [Test]
    public void GetMultipleNeighbours()
    {
        var board = new Board();
        board.Cells = new List<Cell>
        {
            new(board, new Point(5, 5)),
            new(board, new Point(5, 4)),
            new(board, new Point(1, 1))
        };

        var neighbours = board.GetNeighbours(new Point(4, 4));

        Assert.That(neighbours.Count == 2);
    }

    [Test]
    public void CheckAllNeighboursCanBeFound()
    {
        var board = new Board();
        board.Cells = new List<Cell>
        {
            new(board, new Point(3, 3)),
            new(board, new Point(3, 2)),
            new(board, new Point(2, 2)),
            new(board, new Point(2, 3)),
            new(board, new Point(2, 4)),
            new(board, new Point(3, 4)),
            new(board, new Point(4, 4)),
            new(board, new Point(4, 3)),
            new(board, new Point(4, 2))
        };

        var neighbours = board.GetNeighbours(new Point(3, 3));
        
        Assert.That(neighbours.Count == 8);
    }
}
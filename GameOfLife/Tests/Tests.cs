using System.Drawing;
using GameOfLife.Classes;
using NUnit.Framework;

namespace GameOfLife.Tests;

public class Tests
{
    [Test]
    public void GetNeighbours()
    {
        var board = new Board();

        var neighbours = board.GetNeighbours(new Point(10, 9));

        Assert.That(neighbours.Count == 2);
    }
}
using System.Drawing;
using GameOfLife.Classes;
using NUnit.Framework;

namespace GameOfLife.Tests;

public class Tests
{
    [Test]
    public void GetNeighbours()
    {
        var board = new Board
        {
            Cells = new List<Cell>
            {
                new()
                {
                    Location = new Point(10, 10)
                },
                new()
                {
                    Location = new Point(9, 9)
                }
            }
        };

        var neighbours = board.GetNeighbours(new Point(10, 9));
        
        Assert.That(neighbours.Count == 2);
    }
}
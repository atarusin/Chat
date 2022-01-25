using ColorsSort;
using NUnit.Framework;
using System.Collections.Generic;

namespace ColorsSortTests
{
    public class GameBoardTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DifferentGameBoardObject_IfHasEqualValue_WillBeEquals()
        {
            Color<int> color1 = new(1);
            Color<int> color2 = new(2);
            ColorSet<int> set1 = new(new[] { color1, color2 }, 3);
            ColorSet<int> set2 = new(new[] { color2, color1 }, 3);
            ColorSet<int> set3 = new(3);
            GameBoard<int> board1 = new(new List<ColorSet<int>>() { set1, set2, set3 });
            GameBoard<int> board2 = new(new List<ColorSet<int>>() { set1, set2, set3 });

            Assert.IsFalse(object.ReferenceEquals(board1, board2));
            Assert.IsTrue(board1.GetHashCode() == board2.GetHashCode());
            Assert.IsTrue(board1.Equals(board2));
            Assert.IsTrue(board1 == board2);
        }
    }
}
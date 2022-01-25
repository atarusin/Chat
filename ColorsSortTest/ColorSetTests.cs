using ColorsSort;
using NUnit.Framework;

namespace ColorsSortTests
{
    public class ColorSetTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DifferentColorSetsObject_IfHasEqualValue_WillBeEquals()
        {
            Color<int> color1 = new(1);
            Color<int> color2 = new(2);
            ColorSet<int> set1 = new(new[] { color1, color2 }, 3);
            ColorSet<int> set2 = new(new[] { color1, color2 }, 3);

            Assert.IsFalse(object.ReferenceEquals(set1, set2));
            Assert.IsTrue(set1.GetHashCode() == set2.GetHashCode());
            Assert.IsTrue(set1.Equals(set2));
            Assert.IsTrue(set1 == set2);
        }
    }
}
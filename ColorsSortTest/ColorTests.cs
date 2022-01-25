using ColorsSort;
using NUnit.Framework;

namespace ColorsSortTests
{
    public class ColorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Color_ToString_ReturnIsValue()
        {
            int v = 111111;
            Color<int> color = new(v);

            Assert.IsTrue(v.ToString() == color.ToString());
        }

        [Test]
        public void DifferentColorsObject_IfHasEqualValue_WillBeEquals()
        {
            int v = 111111;
            Color<int> color1 = new(v);
            Color<int> color2 = new(v);

            Assert.IsFalse(object.ReferenceEquals(color1, color2));
            Assert.IsTrue(color1 == color2);
        }
    }
}
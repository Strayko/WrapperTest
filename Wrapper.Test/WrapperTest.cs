using System;
using NUnit.Framework;

namespace Wrapper.Test
{
    public class WrapperTest
    {
        [Test]
        public void ShouldWrap()
        {
            AssertWraps(null, 1, "");
            AssertWraps("", 1, "");
            AssertWraps("x", 1, "x");
            AssertWraps("xx", 1, "x\nx");
            AssertWraps("xxx", 1, "x\nx\nx");
            AssertWraps("x x", 1, "x\nx");
            AssertWraps("x xx", 3, "x\nxx");
        }

        private void AssertWraps(string s, int width, string expected)
        {
            Assert.AreEqual(expected, Wrap(s, width));
        }

        private string Wrap(string s, int width)
        {
            if (s == null)
                return "";
            if (s.Length <= width)
            {
                return s;
            }
            else
            {
                int breakPoint = s.LastIndexOf(" ", width, StringComparison.Ordinal);
                if (breakPoint == -1)
                {
                    breakPoint = width;
                }
                return s.Substring(0, breakPoint) + "\n" + Wrap(s.Substring(breakPoint).Trim(), width);
            }
        }
    }
}
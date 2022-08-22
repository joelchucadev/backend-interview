using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Code.Service.Test
{
    public class PatternSolverTest
    {
        private PatternSolver _solver;
        public PatternSolverTest()
        {
            _solver = new PatternSolver();
        }

        [Fact]
        public void FindPatter_EmptyInput_EmptyResult()
        {
            var result = _solver.FindPattern("");
            Assert.Equal(result, string.Empty);
        }

        [Fact]
        public void FindPatter_NullInput_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => _solver.FindPattern(input: null));
        }

        [Theory]
        [InlineData("jafgyA", "fg")]
        [InlineData("Qc1uoTgfd", "o")]
        [InlineData("n3urcaVsw4r7", "aV")]
        [InlineData("iO4L", "O4")]
        [InlineData("GsF", "s")]
        [InlineData("as", "as")]
        [InlineData("L", "L")]
        public void FindPattern_TestCases_MatchExpected(string input, string expected)
        {
            Assert.Equal(_solver.FindPattern(input), expected);
        }
            
    }
}

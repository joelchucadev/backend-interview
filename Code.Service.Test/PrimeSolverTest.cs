using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Code.Service.Test
{
    public class PrimeSolverTest
    {
        private PrimeSolver primeSolver;

        public PrimeSolverTest()
        {
            primeSolver = new PrimeSolver();
        }

        [Fact]
        public void GetPrimes_StartNumberNegative_ReturnEmptyResult()
        {
            var result = primeSolver.GetPrimes(-1, 5);
            Assert.Empty(result);
        }

        [Fact]
        public void GetPrimes_NPrimesNegative_ReturnEmptyResult()
        {
            var result = primeSolver.GetPrimes(4, -5);
            Assert.Empty(result);
        }

        [Fact]
        public void GetPrimes_StartNumberZero_ReturnResult()
        {
            var result = primeSolver.GetPrimes(0, 5);
            Assert.True(result.Any());
        }

        public static IEnumerable<object[]> TestGetPrimesData =>
        new List<object[]>
        {
            new object[] { 2, 5, new List<int>() { 2, 3, 5, 7, 11} },
            new object[] { 2, 10, new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29} },
            new object[] { 2, 20, new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31,
                37, 41, 43, 47, 53, 59, 61, 67, 71} },
        };

        [Theory]
        [MemberData(nameof(TestGetPrimesData))]
        public void GetPrimes_TestCases_ShouldMatchResult(int start, int length, IEnumerable<int> expectedPrimes)
        {
            var result = primeSolver.GetPrimes(start, length);
            Assert.Equal(expectedPrimes, result);
        }
    }
}
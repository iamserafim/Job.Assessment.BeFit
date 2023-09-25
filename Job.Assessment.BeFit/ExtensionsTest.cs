using System.Collections;
using Xunit;

namespace Job.Assessment.BeFit;

public class ExtensionsTest
{
    public class GetPartialSums
    {
        [Theory]
        [InlineData(5, new double[] {1, 3, 12, 6, 43, 8, 10}, new double[] {1, 4, 16, 22, 65})]
        [InlineData(7, new double[] {1, 3, 12, 6, 43, 8, 10}, new double[] {1, 4, 16, 22, 65, 73, 83})]
        [InlineData(9, new double[] {1, 3, 12, 6, 43, 8, 10}, new double[] {1, 4, 16, 22, 65, 73, 83})]
        public void Check_That_Sums_Are_Correct(int n, double[] series, double[] expectedSums) =>
            Assert.True(
                StructuralComparisons.StructuralEqualityComparer.Equals(
                    expectedSums,
                    series.GetPartialSums(n).ToArray()));
    }
    
    public class CanPresentNumber
    {
        [Theory]
        [InlineData(true, 10, new [] {3, 1, 8, 5, 4})]
        [InlineData(true, 11, new [] {3, 1, 8, 5, 4})]
        [InlineData(false, 2, new [] {3, 1, 8, 5, 4})]
        public void Check_That_Result_Is_Correct(bool expectedResult, int number, int[] array) => 
            Assert.Equal(expectedResult, array.CanPresentNumber(number));
    }
}
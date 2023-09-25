namespace Job.Assessment.BeFit;

public static class Extensions
{
    public static IEnumerable<double> GetPartialSums(this IEnumerable<double> series, int n)
    {
        var currentSum = 0.0;
        
        return series
            .Take(n)
            .Select(number => currentSum += number)
            .ToList();
    }

    public static bool CanPresentNumber(this IEnumerable<int> array, int number)
    {
        static bool CanPresentNumberRecursive(IReadOnlyList<int> numbers, int targetSum, int currentIndex)
        {
            return targetSum is 0
                    || targetSum >= 0 
                        && currentIndex != numbers.Count
                        && (CanPresentNumberRecursive(numbers, targetSum - numbers[currentIndex], currentIndex + 1)
                    || CanPresentNumberRecursive(numbers, targetSum, currentIndex + 1));
        }

        return CanPresentNumberRecursive(array.Distinct().ToArray(), number, 0);
    }
}
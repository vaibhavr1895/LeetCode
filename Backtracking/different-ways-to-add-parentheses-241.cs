using System.Collections.Generic;

public IList<int> DiffWaysToCompute(string expression)
{

    List<int> BackTrack(int left, int right)
    {
        List<int> result = new List<int>();

        for (int i = left; i <= right; i++)
        {
            if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*')
            {
                var nums1 = BackTrack(left, i - 1);
                var nums2 = BackTrack(i + 1, right);

                foreach (var n1 in nums1)
                {
                    foreach (var n2 in nums2)
                    {
                        if (expression[i] == '+')
                        {
                            var ans = n1 + n2;
                            result.Add(ans);
                        }
                        if (expression[i] == '-')
                        {
                            var ans = n1 - n2;
                            result.Add(ans);
                        }
                        if (expression[i] == '*')
                        {
                            var ans = n1 * n2;
                            result.Add(ans);
                        }
                    }
                }
            }
        }

        if (result.Count == 0)
        {
            int num1 = int.Parse(expression.Substring(left, right - left + 1));
            result.Add(num1);
        }
        return result;
    }

    return BackTrack(0, expression.Length - 1);
}
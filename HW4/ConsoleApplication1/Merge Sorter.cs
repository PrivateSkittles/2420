
using System;

class mergeSorter : ISorter
{
    public void SortDemValues(int[] values)
    {
        int left = 0;
        int right = values.Length - 1;
        mergeSort(values, left, right);
    }

    public void mergeSort(int[] values, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            mergeSort(values, left, mid);
            mergeSort(values, mid + 1, right);

            int[] lower = new int[mid - left + 1];
            int[] upper = new int[right - mid];

            Array.Copy(values, left, lower, 0, mid - left + 1);
            Array.Copy(values, mid + 1, upper, 0, right - mid);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == lower.Length)
                {
                    values[k] = upper[j];
                    j++;
                }
                else if (j == upper.Length)
                {
                    values[k] = lower[i];
                    i++;
                }
                else if (lower[i] <= upper[j])
                {
                    values[k] = lower[i];
                    i++;
                }
                else
                {
                    values[k] = upper[j];
                    j++;
                }
            }
        }
    }
}

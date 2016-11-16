
class quickSorter : ISorter
{
    public void SortDemValues(int[] values)
    {
        int first = 0;
        int last = values.Length - 1;
        quickSort(values, first, last);
    }

    public void quickSort(int[] values, int first, int last)
    {
        if (first < last)
        {
            int split = partition(values, first, last);
            quickSort(values, first, split - 1);
            quickSort(values, split + 1, last);
        }
    }
    public int partition(int[] values, int first, int last)
    {
        int pivot = values[last];
        int temp = 0;
        int i = first;

        for (int j = first; j < last; j++)
        {
            if (values[j] <= pivot)
            {
                temp = values[j];
                values[j] = values[i];
                values[i] = temp;
                i++;
            }
        }

        values[last] = values[i];
        values[i] = pivot;

        return i;
    }
}

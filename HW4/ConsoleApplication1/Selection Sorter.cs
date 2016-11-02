class selectionSorter : ISorter
{
    public void SortDemValues(int[] values)
    {
        for (int i = 0; i < values.Length; i++)
        {
            int smallestIndex = i;
            for (int j = i + 1; j < values.Length; j++)
                if (values[j] < values[smallestIndex])
                    smallestIndex = j;
            int temp = values[i];
            values[i] = values[smallestIndex];
            values[smallestIndex] = temp;
        }
    }
}

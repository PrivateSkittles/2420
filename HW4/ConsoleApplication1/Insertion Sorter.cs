class insertionSorter : ISorter
{
    public void SortDemValues(int[] values)
    {
        for (int i = 0; i < values.Length; i++)
        {
            int j = i;
            while (j > 0)
            
                if (values[j - 1] > values[j])
                {
                    int temp = values[j - 1];
                    values[j - 1] = values[j];
                    values[j] = temp;
                    j--;
                }
                else
                    break;
        }
    }
}


class bubbleSorter : ISorter
{
    public void SortDemValues(int[] values)
    {
        for (int i = 0; i < values.Length; i++)
        {
            for (int j = 0; j < values.Length - 1; j++)
            {
                if (values[j] > values[j + 1])
                {
                    int temp = values[j + 1];
                    values[j + 1] = values[j];
                    values[j] = temp;
                }
            }
        }            
    }
}

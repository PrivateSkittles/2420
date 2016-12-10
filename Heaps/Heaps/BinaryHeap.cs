using System.Collections.Generic;
using System.Diagnostics;

class BinaryHeap
{
    public List<int> heapList = new List<int>(new int[] { 0 });
    int currentSize = 0;

    public void printList()
    {
        for (int i = 1; i < heapList.Count; i++)
        {
            System.Console.WriteLine(heapList[i]);
        }
    }

    public void add(int value)
    {
        heapList.Add(value);
        currentSize += 1;
        swim(currentSize);
    }

    private void swim(int addedValue)
    {
        while (addedValue / 2 > 0)
        {
            if (heapList[addedValue] > heapList[addedValue / 2])
            {
                int temp = heapList[addedValue / 2];
                heapList[addedValue / 2] = heapList[addedValue];
                heapList[addedValue] = temp;
            }
            addedValue = addedValue / 2;
        }
    }

    public int popTop()
    {
        int valueBeingPopped = heapList[1];
        heapList[1] = heapList[currentSize];
        heapList.RemoveAt(currentSize);
        currentSize -= 1;
        sink(1);
        return valueBeingPopped;
    }

    private void sink(int sinkingValue)
    {
        while ((sinkingValue * 2) <= currentSize)
        {
            int maxChild = findMaxChild(sinkingValue);
            if (heapList[sinkingValue] < heapList[maxChild])
            {
                int temp = heapList[sinkingValue];
                heapList[sinkingValue] = heapList[maxChild];
                heapList[maxChild] = temp;
            }
            sinkingValue = maxChild;
        }
    }

    private int findMaxChild(int i)
    {
        if ((i * 2 + 1) > currentSize) //if there is only one child, return that child
            return i * 2;
        else //returns child with smaller value
        {
            if (heapList[i * 2] > heapList[i * 2 + 1])
                return i * 2;
            else
                return i * 2 + 1;
        }
    }

    public void buildHeap(List<int> aList)
    {
        int sinkingValue = (aList.Count) / 2;
        currentSize = aList.Count - 1;
        for (int i = 1; i < aList.Count; i++)
        {
            if (i > heapList.Count - 1) //edge case if heap being overwritten is smaller than heap being built
                heapList.Add(aList[i]);
            else //overwrites existing heap
                heapList[i] = aList[i];
        }
        while (sinkingValue > 0) //builds heap
        {
            sink(sinkingValue);
            sinkingValue -= 1;
        }
    }

    public void heapSort()
    {
        for (int index = currentSize; index > 0; index--)
        {
            int temp = heapList[1];
            heapList[1] = heapList[index];
            heapList[index] = temp;
            currentSize--;
            sink(1);
        }
    }

    public int this[int index]
    {
        get { return heapList[index + 1]; }
    }

    public void testInvariants()
    {
        for (int index = 1; index < currentSize / 2; index++)
        {
            Debug.Assert(heapList[index] > heapList[index * 2] && heapList[index] > heapList[index * 2 + 1]);
        }
    }
}

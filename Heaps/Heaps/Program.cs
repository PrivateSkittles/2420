using System.Collections.Generic;

class BinaryHeap
{
    List<int> heapList = new List<int>(new int[] { 0 });
    int currentSize = 0;

    public void printList()
    {
        foreach (int value in heapList)
        {
            System.Console.WriteLine(value);
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
            if (heapList[addedValue] < heapList[addedValue / 2])
            {
                int temp = heapList[addedValue / 2];
                heapList[addedValue / 2] = heapList[addedValue];
                heapList[addedValue] = temp;
            }
            addedValue = addedValue / 2;
        }
    }

    public void popTop()
    {
        heapList[1] = heapList[currentSize];
        heapList.RemoveAt(currentSize);
        currentSize -= 1;
        sink(1);
    }

    private void sink(int sinkingValue)
    {
        while ((sinkingValue * 2) <= currentSize)
        {
            int minChild = findMinChild(sinkingValue);
            if (heapList[sinkingValue] > heapList[minChild])
            {
                int temp = heapList[sinkingValue];
                heapList[sinkingValue] = heapList[minChild];
                heapList[minChild] = temp;           
            }
            sinkingValue = minChild;
        }
    }

    private int findMinChild(int i)
    {
        if ((i * 2 + 1) > currentSize)
            return i * 2;
        else
        {
            if (heapList[i * 2] < heapList[i * 2 + 1])
                return i * 2;
            else
                return i * 2 + 1;
        }
    }
 
}


class MainClass
{
    static void Main()
    {
        BinaryHeap binaryHeap = new BinaryHeap();

        binaryHeap.add(5);
        binaryHeap.add(2);
        binaryHeap.add(1);
        binaryHeap.add(21);
        binaryHeap.add(12);
        binaryHeap.add(2);
        binaryHeap.add(4);

        binaryHeap.popTop();
        binaryHeap.popTop();

        binaryHeap.printList();
    }
}
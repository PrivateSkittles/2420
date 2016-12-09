using System.Collections.Generic;
using System.Diagnostics;

class BinaryHeap
{
    public List<int> heapList = new List<int>(new int[] { 0 });
    int currentSize = 0;

    public void printList()
    {
        for (int i = 1; i < heapList.Count ; i++)
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
            if (heapList[addedValue] < heapList[addedValue / 2])
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
        if ((i * 2 + 1) > currentSize) //if there is only one child, return that child
            return i * 2;
        else //returns child with smaller value
        {
            if (heapList[i * 2] < heapList[i * 2 + 1])
                return i * 2;
            else
                return i * 2 + 1;
        }
    }

    public void heapSort()
    {

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

        System.Console.WriteLine("Binary Heap with values 5, 2, 1, 21, 12, 2, 4 added");
        binaryHeap.printList();
        System.Console.WriteLine();

        System.Console.WriteLine("Binary Heap popTop assert test");
        //loop pops until heap is empty and asserts each value popped is larger than previous popped value
        for (int previousPop = binaryHeap.popTop(); binaryHeap.heapList.Count != 1;)
        {
            binaryHeap.printList();
            int currentPop = binaryHeap.popTop();
            Debug.Assert(previousPop <= currentPop);
            previousPop = currentPop;
            System.Console.WriteLine();
        }

        System.Console.WriteLine("Heap empty");
    }
}
using System.Collections.Generic;
using System.Diagnostics;

class MainClass
{
    static void Main()
    {
        BinaryHeap binaryHeap = new BinaryHeap();

        binaryHeap.add(2);
        binaryHeap.add(16);
        binaryHeap.add(12);
        binaryHeap.add(7);
        binaryHeap.add(5);
        binaryHeap.add(12);
        binaryHeap.add(1);

        binaryHeap.testInvariants();

        System.Console.WriteLine("Binary Max Heap with values added 2, 16, 12, 7, 5, 12, 1 using add() function");
        binaryHeap.printList();
        System.Console.WriteLine();

        System.Console.WriteLine("Binary Heap popTop assert test");
        //loop pops until heap is empty and asserts each value popped is larger than previous popped value
        //also asserts invariants are kept through each iteration
        for (int previousPop = binaryHeap.popTop(); binaryHeap.heapList.Count != 1;)
        {
            binaryHeap.printList();
            System.Console.WriteLine();
            int currentPop = binaryHeap.popTop();
            Debug.Assert(previousPop >= currentPop);
            binaryHeap.testInvariants();
            previousPop = currentPop;
        }

        List<int> myList = new List<int>(new int[] { 0, 5, 2, 1, 21, 12, 2, 4, 8});
        binaryHeap.buildHeap(myList);

        binaryHeap.testInvariants();

        System.Console.WriteLine("Binary Max Heap with values 5, 2, 1, 21, 12, 2, 4 added using buildHeap() function");
        binaryHeap.printList();
        System.Console.WriteLine();

        System.Console.WriteLine("Heap Sort");
        binaryHeap.heapSort();
        binaryHeap.printList();

        for (int i = 0; i < binaryHeap.heapList.Count - 2; i++)
        {
            Debug.Assert(binaryHeap[i] <= binaryHeap[i + 1]);
        }
    }
}
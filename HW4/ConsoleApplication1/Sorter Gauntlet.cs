using System;
using System.Diagnostics;

class sorterGauntlet
{
    Random randy = new Random();
    ISorter meSorter;

    public void beatUpASorter(ISorter sorter)
    {
        meSorter = sorter;
        int numPunchesInTheFace = randy.Next(5, 25);
        for (int i = 0; i < numPunchesInTheFace; i++)
        {
            simpleTest();
            testLotsofValues();
            testSortedValues();
            testListOfOne();
            testReversedValues();
            testEmptyList();
            testListOfTwo();
        }
    }

    public void testDataIsSorted(int[] numbers)
    {
        for (int i = 0; i < numbers.Length - 1; i++)
            Debug.Assert(numbers[i] <= numbers[i + 1]);
    }

    public void simpleTest()
    {
        int[] someInts = new[] { 8, 4, 1, 2, 3, 9, 7, 5, 12, 6, 10 };
        meSorter.SortDemValues(someInts);
        testDataIsSorted(someInts);
    }

    public void testListOfTwo()
    {
        int[] someInts = new int[2] { 8, 4 };
        meSorter.SortDemValues(someInts);
        testDataIsSorted(someInts);
    }

    public void testEmptyList()
    {
        int[] someInts = new int[0] ;
        meSorter.SortDemValues(someInts);
        testDataIsSorted(someInts);
    }

    public void testReversedValues()
    {
        int[] someInts = new int[5] { 10, 8, 5, 2, 0};
        meSorter.SortDemValues(someInts);
        testDataIsSorted(someInts);
    }

    public void testListOfOne()
    {
        int[] someInts = new int[1] { 7 };
        meSorter.SortDemValues(someInts);
        testDataIsSorted(someInts);
    }

    public void testSortedValues()
    {
        int[] someInts = new int[5] { 2, 9, 15, 28, 7 };
        meSorter.SortDemValues(someInts);
        testDataIsSorted(someInts);
    }

    public void testLotsofValues()
    {

    }
}



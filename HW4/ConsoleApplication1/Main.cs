using System.Collections.Generic;
using System;
using System.Diagnostics;


class MainClass
{
    static void Main()
    {
        sorterGauntlet theGauntlet = new sorterGauntlet();

        System.Console.WriteLine("Selection Sorter");
        theGauntlet.beatUpASorter(new selectionSorter());
        Console.WriteLine();

        System.Console.WriteLine("Insertion Sorter");
        theGauntlet.beatUpASorter(new insertionSorter());
        Console.WriteLine();

        System.Console.WriteLine("Bubble Sorter");
        theGauntlet.beatUpASorter(new bubbleSorter());
        Console.WriteLine();

        System.Console.WriteLine("Merge Sorter");
        theGauntlet.beatUpASorter(new mergeSorter());
        Console.WriteLine();

        Console.WriteLine("Quick Sorter");
        theGauntlet.beatUpASorter(new quickSorter());
        Console.WriteLine();

        List<string> myList = new List<string>();
        Debug.Assert(myList.Count == 0);
        myList.Add("Jamie");
        myList.Add("Bob");
        myList.Add("Jill");
        Debug.Assert(myList.Count == 3);

        List<int> myListOfInts = new List<int>();
        myListOfInts.Add(5);
        myListOfInts.Add(7);
    } 
}
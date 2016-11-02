using System.Collections.Generic;
using System;

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
    } 
}
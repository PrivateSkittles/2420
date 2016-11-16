using System.Collections.Generic;
using System;
using System.Diagnostics;


class MainClass
{
    static void Main()
    {
        sorterGauntlet theGauntlet = new sorterGauntlet();

        theGauntlet.beatUpASorter(new selectionSorter());
        theGauntlet.beatUpASorter(new insertionSorter());
        theGauntlet.beatUpASorter(new bubbleSorter());
        theGauntlet.beatUpASorter(new mergeSorter());
        theGauntlet.beatUpASorter(new quickSorter());

        List<string> myList = new List<string>();
        Debug.Assert(myList.Count == 0);
        myList.Add("Jamie");
        myList.Add("Bob");
        myList.Add("Jill");
        myList.Add("Sue");
        Debug.Assert(myList.Count == 4);

        bool doesListContain = myList.contains("Jill");
        Debug.Assert(doesListContain == true);

        int indexPos = myList.IndexOf("Bob");
        Debug.Assert(indexPos == 1);

    } 
}
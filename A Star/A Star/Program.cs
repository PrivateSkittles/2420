using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        aStar aStar = new aStar();
        Node startNode = new Node();
        Node endNode = new Node();
        List<Node> nodeList = new List<Node>();
        aStar.setUpNodes(nodeList);

        Console.WriteLine("Enter start node: ");
        startNode.name = Console.ReadLine();
        Console.WriteLine("Enter end node: ");
        endNode.name = Console.ReadLine();
        Console.WriteLine("Your path: "); 

        foreach (Node nodeFind in nodeList)
        {
            if (startNode.name.ToUpper() == nodeFind.name)
                startNode = nodeFind;
            if (endNode.name.ToUpper() == nodeFind.name)
                endNode = nodeFind;
        }

        List<Node> closedList = new List<Node>();
        aStar.testNode(startNode, startNode, endNode, closedList);

    }
}
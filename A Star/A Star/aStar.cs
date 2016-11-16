
using System;
using System.Collections.Generic;

class aStar
{
    public Node processNode(Node currentNode, Node previousNode, Node endNode)
    {
        if (currentNode.parentNode != null)
            currentNode.CSF += currentNode.parentNode.CSF + distance(currentNode.parentNode, currentNode);
        else
            currentNode.CSF += distance(previousNode, currentNode);
        currentNode.H = distance(currentNode, endNode);
        currentNode.TEC = currentNode.H + currentNode.CSF;
        return currentNode;
    }


    public double distance(Node currentNode, Node goalNode)
    {
        double startX = currentNode.location[0];
        double startY = currentNode.location[1];

        double endX = goalNode.location[0];
        double endY = goalNode.location[1];

        double nodeDistance = Math.Sqrt(Math.Pow(endX - startX, 2) + Math.Pow(endY - startY, 2));
        return nodeDistance;
    }

    public Node initializeNode(double[] location, string name)
    {
        Node newNode = new Node();
        newNode.name = name;
        newNode.CSF = 0;
        newNode.location = location;
        return newNode;
    }


    public void testNode(Node currentNode, Node startNode, Node endNode, List<Node> closedList)
    {
        List<Node> openList = new List<Node>();
        Node processedNode = null;
        Node smallestNode = null;
        Node current = null;

        if (currentNode.name == startNode.name)
        {
            processedNode = processNode(currentNode, startNode, endNode);
            closedList.Add(processedNode);
            for (int i = 0; i < currentNode.connectedNodes.Count; i++)
            {
                current = currentNode.connectedNodes[i];
                current.parentNode = currentNode;
                processedNode = processNode(current, startNode, endNode);
                openList.Add(processedNode);
            }

        }

        else
        {
            for (int i = 0; i < currentNode.connectedNodes.Count; i++)
            {
                current = currentNode.connectedNodes[i];
                current.parentNode = currentNode;
                processedNode = processNode(current, startNode, endNode);
                if (currentNode.parentNode.name != current.name)
                    openList.Add(processedNode);
            }
        }

        foreach (Node nodeNumber in openList)
        {
            if (smallestNode == null)
                smallestNode = nodeNumber;
            if (smallestNode.TEC > nodeNumber.TEC && smallestNode.H > nodeNumber.H)
                smallestNode = nodeNumber;
        }

        closedList.Add(smallestNode);

        if (smallestNode.name == endNode.name)
        {
            foreach (Node nodePath in closedList)
            {
                Console.WriteLine(nodePath.name);
            }
        }
        else
            testNode(smallestNode, startNode, endNode, closedList);
    }

    public void setUpNodes(List<Node> nodeList)
    {

        Node a = initializeNode(new double[2] { -19, 11 }, "A");
        nodeList.Add(a);
        Node b = initializeNode(new double[2] { -13, 13 }, "B");
        nodeList.Add(b);
        Node c = initializeNode(new double[2] { 4, 14 }, "C");
        nodeList.Add(c);
        Node d = initializeNode(new double[2] { -4, 12 }, "D");
        nodeList.Add(d);
        Node e = initializeNode(new double[2] { -8, 3 }, "E");
        nodeList.Add(e);
        Node f = initializeNode(new double[2] { -18, 1 }, "F");
        nodeList.Add(f);
        Node g = initializeNode(new double[2] { -12, -8 }, "G");
        nodeList.Add(g);
        Node h = initializeNode(new double[2] { 12, -9 }, "H");
        nodeList.Add(h);
        Node i = initializeNode(new double[2] { -18, -11 }, "I");
        nodeList.Add(i);
        Node j = initializeNode(new double[2] { -4, -11 }, "J");
        nodeList.Add(j);
        Node k = initializeNode(new double[2] { -12, -14 }, "K");
        nodeList.Add(k);
        Node l = initializeNode(new double[2] { 2, -18 }, "L");
        nodeList.Add(l);
        Node m = initializeNode(new double[2] { 18, -13 }, "M");
        nodeList.Add(m);
        Node n = initializeNode(new double[2] { 4, -9 }, "N");
        nodeList.Add(n);
        Node o = initializeNode(new double[2] { 22, 11 }, "O");
        nodeList.Add(o);
        Node p = initializeNode(new double[2] { 18, 3 }, "P");
        nodeList.Add(p);

        a.connectedNodes.Add(b);
        a.connectedNodes.Add(e);

        b.connectedNodes.Add(a);
        b.connectedNodes.Add(d);

        c.connectedNodes.Add(d);
        c.connectedNodes.Add(e);
        c.connectedNodes.Add(p);

        d.connectedNodes.Add(b);
        d.connectedNodes.Add(e);
        d.connectedNodes.Add(c);

        e.connectedNodes.Add(a);
        e.connectedNodes.Add(d);
        e.connectedNodes.Add(c);
        e.connectedNodes.Add(g);
        e.connectedNodes.Add(j);
        e.connectedNodes.Add(n);
        e.connectedNodes.Add(h);

        f.connectedNodes.Add(i);
        f.connectedNodes.Add(g);

        g.connectedNodes.Add(f);
        g.connectedNodes.Add(e);
        g.connectedNodes.Add(j);

        h.connectedNodes.Add(e);
        h.connectedNodes.Add(n);
        h.connectedNodes.Add(p);

        i.connectedNodes.Add(f);
        i.connectedNodes.Add(k);

        j.connectedNodes.Add(e);
        j.connectedNodes.Add(g);
        j.connectedNodes.Add(n);
        j.connectedNodes.Add(k);
        j.connectedNodes.Add(l);

        k.connectedNodes.Add(i);
        k.connectedNodes.Add(j);
        k.connectedNodes.Add(l);

        l.connectedNodes.Add(k);
        l.connectedNodes.Add(j);
        l.connectedNodes.Add(m);

        m.connectedNodes.Add(l);
        m.connectedNodes.Add(o);

        n.connectedNodes.Add(j);
        n.connectedNodes.Add(e);
        n.connectedNodes.Add(h);

        o.connectedNodes.Add(p);
        o.connectedNodes.Add(m);

        p.connectedNodes.Add(c);
        p.connectedNodes.Add(h);
        p.connectedNodes.Add(m);
        p.connectedNodes.Add(o);

    }

}

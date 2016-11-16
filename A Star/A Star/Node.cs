using System.Collections.Generic;

class Node
{
    public double CSF = 0;
    public double H { get; set; }
    public double TEC { get; set; }
    public Node parentNode { get; set; }
    public double[] location = new double[2] { 0, 0 };
    public string name { get; set; }
    public List<Node> connectedNodes = new List<Node>();
}

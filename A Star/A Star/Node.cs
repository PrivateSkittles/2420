using System.Collections.Generic;

class Node
{
    public float CSF = 0;
    public float H { get; set; }
    public float TEC { get; set; }
    public Node parentNode { get; set; }
    public float[] location = new float[2] { 0, 0 };
    public string name { get; set; }
    public List<Node> connectedNodes = new List<Node>();
}

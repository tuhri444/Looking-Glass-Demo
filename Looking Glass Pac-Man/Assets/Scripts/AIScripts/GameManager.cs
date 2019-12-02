using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public List<Node> nodes = new List<Node>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name.Contains("Pipe")|| transform.GetChild(i).name.Contains("Cube"))
            {
                Node node = new Node();
                node.Position = transform.GetChild(i).position;
                nodes.Add(node);
            }
        }
        for (int i = 0; i < nodes.Count; i++)
        {
            for (int j = 0; j < nodes.Count; j++)
            {
                if (i != j)
                {
                    if (Vector3.Distance(nodes[i].Position, nodes[j].Position) <=1f)
                    {
                        nodes[i].add(nodes[j]);
                    }
                }
            }
        }
    }
}
public class Node
{
    Vector3 position;
    List<Node> connectionsToNodes = new List<Node>();
    public float f = 0;//total cost
    public float g = 0;//dist between current and start
    public float h = 0;//dist between this and end
    public Node() { }
    public void add(Node n)
    {
        connectionsToNodes.Add(n);
    }
    public Vector3 Position
    {
        get { return position; }
        set { position = value; }
    }
    public List<Node> connectionsList
    {
        get { return connectionsToNodes; }
    }
    public int connections
    {
        get { return connectionsToNodes.Count; }
    }
}

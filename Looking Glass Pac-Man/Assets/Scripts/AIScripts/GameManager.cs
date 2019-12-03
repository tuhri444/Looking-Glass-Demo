using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public List<Node> nodes = new List<Node>();
    List<Transform> children = new List<Transform>();
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name.Contains("Pipe") || transform.GetChild(i).name.Contains("Cube"))
            {
                children.Add(transform.GetChild(i));
                Node node = new Node();
                node.Position = transform.GetChild(i).localPosition;
                nodes.Add(node);
            }
        }
        for (int i = 0; i < nodes.Count; i++)
        {
            for (int j = 0; j < nodes.Count; j++)
            {
                if (i != j)
                {
                    if (Vector3.Distance(nodes[i].Position, nodes[j].Position) <= 0.15f)
                    {
                        nodes[i].add(nodes[j]);
                    }
                }
            }
        }
        //int count = 0;

        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    //if (transform.GetChild(i).name.Contains("Pipe") || transform.GetChild(i).name.Contains("Cube"))
        //    //{
        //        count++;
        //    //}
        //}
        //Debug.Log(count);
    }

    void Update()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            nodes[i].Position = children[i].localPosition;
        }

        foreach (Node n in nodes)
        {
            foreach (Node child in n.connectionsList)
            {
                Debug.DrawLine(n.Position, child.Position, Color.blue);
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
        get
        {
            //position = new Vector3(position.x,0,position.z);
            return position;
        }
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

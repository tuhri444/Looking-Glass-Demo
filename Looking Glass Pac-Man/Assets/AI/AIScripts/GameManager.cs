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
            if (transform.GetChild(i).name.Contains("Pipe") || transform.GetChild(i).name.Contains("Cube")|| transform.GetChild(i).name.Contains("Teleporter"))
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
                    if (Vector3.Distance(nodes[i].Position, nodes[j].Position) <= .17f)
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

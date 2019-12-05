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
            if (transform.GetChild(i).GetComponent<Node>() != null)
            {
                children.Add(transform.GetChild(i));
                transform.GetChild(i).GetComponent<Node>().Position = transform.GetChild(i).localPosition;
                nodes.Add(transform.GetChild(i).GetComponent<Node>());
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

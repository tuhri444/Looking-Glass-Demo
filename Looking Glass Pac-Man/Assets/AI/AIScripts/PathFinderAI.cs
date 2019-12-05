using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderAI : MonoBehaviour
{
    GameManager gm;

    public Vector3 startPos;
    public Vector3 previousPos;
    public Vector3 currentPos;
    public Vector3 nextNodePos;
    public Vector3 target;

    Node previousNode;
    public Node currentNode;
    Node nextNode;

    Quaternion targetRotation;
    bool move = false;
    bool turning;
    Node lowest;
    float counter = 0;
    float startCounter = 0;
    float turnSpeed;
    float max = float.MaxValue;
    float max2 = float.MaxValue;
    private float speed = 1;
    private VariableManager vm;
    
    void Start()
    {
        gm = transform.parent.GetComponent<GameManager>();
        currentNode = FindMatch();
        transform.localPosition = currentNode.Position;
        startPos = transform.localPosition;
        currentPos = startPos;
        previousNode = currentNode;
        previousPos = currentPos;
        target = startPos;
        vm = FindObjectOfType<VariableManager>();

    }

    void Update()
    {
        switch (gameObject.name)
        {
            case "Blinky":
                Blinky b = GetComponent<Blinky>();
                target = b.currentMode ==Blinky.MoveMode.SCATTER? target:FindMatch(target).Position;
                break;
            case "Pinky":
                Pinky p = GetComponent<Pinky>();
                target = p.currentMode == Pinky.MoveMode.SCATTER ? target : FindMatch(target).Position;
                break;
            case "Inky":
                Inky I = GetComponent<Inky>();
                target = I.currentMode == Inky.MoveMode.SCATTER ? target : FindMatch(target).Position;
                break;
            case "Clyde":
                Clyde C = GetComponent<Clyde>();
                target = C.currentMode == Clyde.MoveMode.SCATTER ? target : FindMatch(target).Position;
                break;

        }
        if (Vector3.Distance(currentPos,target) > 0.08f)
        {
            if (!move)
            {
                max = float.MaxValue;
                for (int i = 0; i < currentNode.connections; i++)
                {
                    //Debug.Log("Previous Node" + previousPos);
                    //Debug.Log("CurrentNode Connections"+currentNode.connectionsList[0]);
                    if (currentNode.connectionsList[i] != previousNode)
                    {
                        Node child = currentNode.connectionsList[i];
                        child.g = currentNode.g + Vector3.Distance(currentNode.Position, child.Position);
                        child.h = Vector3.Distance(child.Position, target);
                        child.f = child.g + child.h;
                        if (child.f <= max)
                        {
                            //Debug.Log("Found a Lowest");
                            lowest = child;
                            max = lowest.f;
                        }
                    }
                }

                nextNode = lowest;
                nextNodePos = lowest.Position;
                move = true;
            }
            else if (move && !vm.turning)
            {
                if (counter < 1)
                {
                    counter++;
                    previousPos = currentPos;
                    previousNode = currentNode;
                }

                currentPos = Vector3.MoveTowards(transform.localPosition, nextNode.Position, Time.deltaTime * vm.speed * .1f);
                if (Vector3.Distance(currentPos, nextNode.Position) < 0.0001f)
                {
                    counter = 0;
                    currentPos = nextNodePos;
                    currentNode = nextNode;
                    move = false;
                }
            }
        }
        transform.localPosition = currentPos;
        
    }

    Node FindMatch()
    {
        Node least = null;
        max2 = float.MaxValue;
        for (int i = 0; i<gm.nodes.Count;i++)
        {
            if(Vector3.Distance(gm.nodes[i].Position,transform.localPosition) < max2)
            {
                least = gm.nodes[i];
                max2 = Vector3.Distance(gm.nodes[i].Position, transform.localPosition);
            }
        }
        return least;
    }
    Node FindMatch(Vector3 pos)
    {
        Node least = null;
        max2 = float.MaxValue;
        for (int i = 0; i < gm.nodes.Count; i++)
        {
            if (Vector3.Distance(gm.nodes[i].Position,pos) < max2)
            {
                least = gm.nodes[i];
                max2 = Vector3.Distance(gm.nodes[i].Position, pos);
            }
        }
        return least;
    }
}

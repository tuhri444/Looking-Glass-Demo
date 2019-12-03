using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderAI : MonoBehaviour
{
    GameManager gm;
    public Vector3 target;
    public Vector3 currentPos;
    [HideInInspector] public Vector3 startPos;
    private float speed = 1;
    float max = float.MaxValue;
    Node currentNode;
    Node previousNode;
    public Vector3 previousPos;
    Node nextNode;
    public Vector3 nextNodePos;
    Quaternion targetRotation;
    bool move = false;
    bool turning;
    Node lowest;
    float counter = 0;
    float startCounter = 0;
    float turnSpeed;
    private VariableManager vm;

    void Start()
    {
        gm = transform.parent.GetComponent<GameManager>();
        startPos = transform.localPosition;
        currentNode = gm.nodes[0];
        currentPos = startPos;
        previousNode = currentNode;
        previousPos = currentPos;
        target = startPos;
        vm = FindObjectOfType<VariableManager>();
    }

    void Update()
    { 
        //Debug.Log(gm.nodes[0].connections);
        if (Vector3.Distance(currentPos,target) > 0.08f)
        {
            if (!move)
            {
                max = float.MaxValue;
                for (int i = 0; i < currentNode.connections; i++)
                {
                    Debug.Log("Current Child" + currentNode.connectionsList[i].Position);
                    //Debug.Log("Previous Node" + previousPos);
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
                //transform.localPosition = currentPos;
            }
        }
        transform.localPosition = currentPos;
    }
}

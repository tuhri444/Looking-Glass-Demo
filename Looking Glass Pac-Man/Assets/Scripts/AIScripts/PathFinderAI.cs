using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderAI : MonoBehaviour
{
    GameManager gm;
    [HideInInspector] public Vector3 target;
    [HideInInspector]public Vector3 currentPos;
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

    void Start()
    {
        gm = transform.parent.GetComponent<GameManager>();
        startPos = transform.parent.position;
        transform.position = startPos; 
    }

    void Update()
    {
        turning = FindObjectOfType<VariableManager>().turning;
        speed = FindObjectOfType<VariableManager>().speed;
        targetRotation = FindObjectOfType<VariableManager>().targetRotation;
        turnSpeed = FindObjectOfType<VariableManager>().turnSpeed;
        if (startCounter < 1)
        {
            currentNode = gm.nodes[0];
            currentPos = startPos;
            previousNode = currentNode;
            previousPos = currentPos;
            target = startPos;
            startCounter++;
        }
        if (currentPos != target)
        {
            if (!move)
            {
                max = float.MaxValue;
                for (int i = 0; i < currentNode.connections; i++)
                {
                    //Debug.Log("Current Child" + currentNode.connectionsList[i].Position);
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
            else if (move && !turning)
            {
                if (counter < 1)
                {
                    counter++;
                    previousPos = currentPos;
                }
                currentPos = Vector3.MoveTowards(transform.position, nextNode.Position, Time.deltaTime * speed);
                if (Vector3.Distance(currentPos, nextNode.Position) < .002f)
                {
                    counter = 0;
                    currentPos = nextNodePos;
                    currentNode = nextNode;
                    move = false;
                }
            }
        }
        if (turning)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
            if (transform.rotation == targetRotation)
            {
                transform.rotation = targetRotation;
                turning = false;
            }
        }
        transform.position = currentPos;
    }
}

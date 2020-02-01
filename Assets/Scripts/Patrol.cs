using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public int startNode;
    private int numberOfNodes;
    private int currentNode;

    public Transform[] moveSpots;
    void Start()
    {
        waitTime = startWaitTime;
        currentNode = startNode;
        numberOfNodes = moveSpots.Length;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[NextNode(currentNode)].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[NextNode(currentNode)].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                currentNode = NextNode(currentNode);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private int NextNode(int current)
    {
        int returning = current + 1;
        if(returning == numberOfNodes)
        {
            returning = 0;
        }
        return returning;
    }

    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private EntityData data;
    [SerializeField] private Queue<Vector2> targets;
    //[SerializeField] private Vector2 target;
    public GameObject worldDataObject;
    private WorldData worldData;
    private Vector2 newPosition, currentPosition;

    public void OnEnable()
    {
        Button.OnItemSpawned += AddTargets;
    }

    public void OnDisable()
    {
        Button.OnItemSpawned -= AddTargets;
    }

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Item").GetComponent<Transform>().position;
        targets = new Queue<Vector2>();
        //targets.Enqueue(target);
        worldData = worldDataObject.GetComponent<WorldData>();
        newPosition = worldData.RandSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        // I'm actually so proud of this ;-;
        currentPosition = transform.position;
        if (targets.Count != 0)
        {
            // Reached current target; remove from search
            if (currentPosition == targets.Peek())
            {
                targets.Dequeue();
            }
            // Still need to reach the current target;
            else
            {
                MoveTo(targets.Peek());
            }
        }
        // No targets; random walk
        else
        {
            if (currentPosition == newPosition)
            {
                newPosition = worldData.RandomSpawnPos();
            }
            else
            {
                MoveTo(newPosition);
            }
        }
    }

    private void AddTargets(Vector2 target)
    {
        targets.Enqueue(target);
    }

    private void MoveTo(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, data.movementSpeed * Time.deltaTime);
    }
}

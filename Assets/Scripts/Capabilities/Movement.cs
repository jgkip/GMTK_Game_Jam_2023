using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private EntityData data;
    private Transform target;
    public GameObject worldDataObject;
    private WorldData worldData;
    private Vector2 newPosition, currentPosition;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Item").GetComponent<Transform>();
        worldData = worldDataObject.GetComponent<WorldData>();
        newPosition = worldData.RandSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        /*
        if (target != null)
        {
            MoveTo(target.position);
        }
        */
        
        if (currentPosition == newPosition)
        {
            newPosition = worldData.RandSpawnPos();
        }
        else
        {
            MoveTo(newPosition);
        }
        
        //target = GameObject.FindGameObjectWithTag("Item").GetComponent<Transform>();
    }

    private void MoveTo(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, data.movementSpeed * Time.deltaTime);
    }
}

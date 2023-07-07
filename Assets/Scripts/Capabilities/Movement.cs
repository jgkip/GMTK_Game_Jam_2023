using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Transform target;
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Item").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // if an item exists, go towards it
        // else, random walk 
        if (target != null)
        {
            MoveTowardsItem();
        }
    }

    private void MoveTowardsItem()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}

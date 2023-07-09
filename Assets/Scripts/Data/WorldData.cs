using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldData : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    private Vector2 bounds;
    private float minimumX;
    private float maximumX;
    private float minimumY;
    private float maximumY;

    // Start is called before the first frame update
    void Start()
    {
        minimumX = -20;
        maximumX = 15;
        minimumY = -8;
        maximumY = 8;
        bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        minX = -bounds.x;
        maxX = bounds.x;
        minY = -bounds.y;
        maxY = bounds.y;
    }

    public Vector2 RandSpawnPos()
    {
        return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    public Vector2 RandomSpawnPos()
    {
        return new Vector2(Random.Range(minimumX, maximumX), Random.Range(minimumY, maximumY));
    }
}

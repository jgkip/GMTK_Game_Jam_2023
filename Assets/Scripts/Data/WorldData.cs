using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldData : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    private Vector2 bounds;
    // Start is called before the first frame update
    void Start()
    {
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
}

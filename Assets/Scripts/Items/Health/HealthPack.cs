using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Item
{
    public static event Action<float> OnHealthPickup;
    [SerializeField] private float healthToAdd; 
    private void OnTriggerEnter2D(Collider2D collision) { 
        if (collision.gameObject.tag.Equals("Player")) {
            Consume();
            Destroy(gameObject);
        }
    }

    public override void Consume()
    {
        OnHealthPickup?.Invoke(healthToAdd);
        // Debug.Log("Consumed");
    }
}

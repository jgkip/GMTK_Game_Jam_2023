using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeed : Item
{
    public static event Action<float> OnSpeedPickup;
    [SerializeField] private float speedMultiplier;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Consume();
            Destroy(gameObject);
        }
    }

    public override void Consume()
    {
        OnSpeedPickup?.Invoke(speedMultiplier);
    }
}


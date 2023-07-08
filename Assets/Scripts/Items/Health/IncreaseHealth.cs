using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : Item
{
    public static event Action<float> OnIncreaseMaxHealthPickup;
    [SerializeField] private float increaseAmount;
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
        OnIncreaseMaxHealthPickup?.Invoke(increaseAmount);
    }
}


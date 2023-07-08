using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : Item
{
    public static event Action<float> OnDamagePickup;
    [SerializeField] private float damageMultiplier;
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
        OnDamagePickup?.Invoke(damageMultiplier);
    }
}


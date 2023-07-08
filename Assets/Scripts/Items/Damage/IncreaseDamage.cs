using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : Item
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }

    public override void Consume()
    {
        throw new System.NotImplementedException();
    }
}


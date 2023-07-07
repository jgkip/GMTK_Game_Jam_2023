using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private bool onGround;
    private float friction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    // Reset on grounded flag and friction if not colliding with anything
    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
        friction = 0;
    }

    // Check if a collision is ground collision 
    private void EvaluateCollision(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector2 normal = collision.GetContact(i).normal;
            onGround |= normal.y >= 0.9f;
        }
    }

    
    private void RetrieveFriction(Collision2D collision)
    {
        PhysicsMaterial2D material = collision.rigidbody.sharedMaterial;
        friction = 0; // reset before assigning it!
        if (material != null)
        {
            friction = material.friction;
        }
    }

    public bool GetOnGround()
    {
        return onGround;
    }
    
    public float GetFriction()
    {
        return friction;
    }
}

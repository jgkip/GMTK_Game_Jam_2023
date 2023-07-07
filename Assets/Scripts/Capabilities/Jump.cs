using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 10f)] private float jumpHeight = 3f;
    [SerializeField, Range(0, 5)] private int maxAirJumps = 0;
    [SerializeField, Range(0f, 5f)] private float downwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 5f)] private float upwardMovementMultiplier = 1.7f;
    [SerializeField] private float jumpBufferTimer = 0.5f;

    private Vector2 velocity;
    private Rigidbody2D body;
    private Ground ground;

    private int jumpPhase; // track how many times player has jumped
    private float defaultGravityScale;
    private float mayJump;

    private bool desiredJump; // does player want to jump?
    private bool onGround;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        defaultGravityScale = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (onGround)
        {
            jumpPhase = 0;
            mayJump = jumpBufferTimer;
        }
        else
        {
            mayJump -= Time.deltaTime;
        }

        desiredJump |= input.RetrieveJumpInput();
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = body.velocity;
        
        if (desiredJump && mayJump > 0f) // want to jump; no longer request jump and perform jump action
        {
            desiredJump = false;
            JumpAction();
            mayJump = 0f;
        }
        if (body.velocity.y > 0)
        {
            body.gravityScale = upwardMovementMultiplier;
        }
        else if (body.velocity.y < 0)
        {
            body.gravityScale = downwardMovementMultiplier;
        }
        else if (body.velocity.y == 0)
        {
            body.gravityScale = defaultGravityScale;
        }
        body.velocity = velocity;
    }

    private void JumpAction()
    {
        if (onGround || jumpPhase < maxAirJumps)
        {
            jumpPhase += 1;
            float jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);
            // If player is jumping, make sure that the jump speed never becomes negative
            if (velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }
            velocity.y += jumpSpeed;
        }
    }
}

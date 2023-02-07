using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer spriteRender;
    private EMovementState state;
    [SerializeField] private float speedRun = 7f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float dirX;
    [SerializeField] private LayerMask jumpableGround;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMovement();
    }

    private void OnMovement()
    {
        dirX = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(dirX * speedRun, rigidbody.velocity.y);
        if (Input.GetKeyDown("space") && isGrounded())
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }
        OnAnimatorState();
    }

    private void OnAnimatorState()
    {
        if (dirX > 0)
        {
            state = EMovementState.run;
            spriteRender.flipX = false;
        }else if(dirX < 0)
        {
            state = EMovementState.run;
            spriteRender.flipX = true;
        }
        else
        {
            state = EMovementState.idle;
        }
        if(rigidbody.velocity.y > .1f)
        {
            state = EMovementState.jump;
        }else if(rigidbody.velocity.y < -.1f)
        {
            state = EMovementState.fall;
        }
        anim.SetInteger("movementstate", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f,jumpableGround);
    }

}

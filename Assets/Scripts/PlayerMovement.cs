using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D collide;
    private SpriteRenderer sprite;
    private float dirX = 0f;


    private bool grounded;

   //(Public does the same as SerializeField but it exposes them to others.
   //which can be bad for the intended code.)

   [SerializeField] private float MovementSpeed = 7f;
   [SerializeField] private float JumpStrenght = 14;
   [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //this is your movement code.( @_@)

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * MovementSpeed, rb.velocity.y);

        // this is the jump restricter
        grounded = Physics2D.OverlapCircle(collide.transform.position, 1f, jumpableGround);

        Debug.Log(grounded);

        //this is your jump code.( @-@)
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpStrenght);
        }

        UpdateAnimationCondition();
    }

            private void UpdateAnimationCondition()
            {
                ////This the animation conditions (bool condition in animator)

                if (dirX > 0f)
                {
                    anim.SetBool("Walking", true);//first input if your running
                    sprite.flipX = false;
                }
                else if (dirX < 0f)
                {
                    anim.SetBool("Walking", true);//second input to double,To check your still running '-'.
                    sprite.flipX = true;
                }
                else
                {
                    anim.SetBool("Walking", false);//if not running then switch back to Idle, you lazy ~_~.
                }

            }

    private bool IsGrounded() ///this isnt working for me,right now
    {
        return Physics2D.OverlapCircle(collide.transform.position, 0.01f, jumpableGround);
    }
}
    
        
    


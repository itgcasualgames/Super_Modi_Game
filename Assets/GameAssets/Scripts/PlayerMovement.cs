using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3.25f;
    public float jumpSpeed;
    public Rigidbody2D rb;
    public Animator playerAnim;
    public string currentState;

    public bool canJump,isPause,canFly,isOnpodium,isWithMask,isWithBrick,isOnShikara,isUnderPipe,isShareMode,iscollide;

    public GameObject TapToPlayPanel, modiFace,shikara;

    public Vector3 velocityNew;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        isPause = true;
        canJump = true;
        canFly = false;
        isOnShikara = false;
        iscollide = false;
    }

    // get input values each frame
    private void Update()
    {
        if (!isPause && !isOnpodium && !isOnShikara && !isShareMode)
        {
            if (!canFly && !isWithMask && !isWithBrick)
            {
                if (canJump)
                {

                    changeAnimationState("run");
                }
                else
                {
                    if(rb.velocity.y>0.00f)
                    changeAnimationState("jump start");
                    if (rb.velocity.y < 0.00f)
                        changeAnimationState("jump exit");

                }
            }
            else if (canFly)
            {
                changeAnimationState("run_with_jhadu");
            }
            else if (!canFly && isWithMask && !isWithBrick)
            {
                if (canJump)
                {

                    changeAnimationState("run with mask");
                }
                else
                {
                    changeAnimationState("jump_with_mask");

                }
            }
            else if (!canFly && !isWithMask && isWithBrick)
            {
                if (canJump)
                {

                    changeAnimationState("run with brick");
                }
                else
                {
                    changeAnimationState("jump with brick");

                }
            }
        }
    }

    private void FixedUpdate()
    {

        if (!isPause && !isOnpodium  && !isShareMode)
        {

           run();
        }
        velocityNew = rb.velocity;
        //print(rb.velocity);
    }


    void run()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.World);
    }
    void changeAnimationState(string newState)
    {
        if (currentState == newState)
            return;
        playerAnim.Play(newState);

        currentState = newState;
    }

   public void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        canJump = false;
       
    }

    public void JumpButtonClick()
    {
        if (!isUnderPipe && !isOnShikara && (canJump || canFly))
        {
            jump();
            if(!canFly && !isUnderPipe && !isOnShikara)
            SoundManager.instance.jumping();
        }
       // if(isOnShikara)
         //   transform.Translate(Vector2.right * moveSpeed * Time.deltaTime*20, Space.World);
    }
}

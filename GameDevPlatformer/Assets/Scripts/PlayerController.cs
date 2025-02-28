using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 8f;
    Vector2 moveInput;
    TouchingDirections touchingDirections;
    public float jumpImpule = 10f;

    private bool isGrounded;
    private int jumpCount = 0;
    private int maxJumpCount = 1;
    public float CurrentMoveSpeed { get 
        {
            if (CanMove)
            {
                if (IsMoving && !touchingDirections.IsOnWall)
                {
                    return walkSpeed;
                }
                else
                {
                    //idel
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        } 
    }
    [SerializeField]
    private bool _isMoving = false;

    public bool IsMoving { get 
        {
            return _isMoving;
        } private set 
        { 
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }

    public bool _isFacingRight = true;

    public bool IsFacingRight { get 
        {
            return _isFacingRight;
        } private set 
        {
            if (IsFacingRight != value) 
            {
                //flip scale to make the player face the opposite direction
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    Rigidbody2D rb;
    Animator animator;

    public bool CanMove { get 
        {
            return animator.GetBool(AnimationStrings.canMove);
        } }

    public bool IsAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    
    private void FixedUpdate()
    {

        

        rb.linearVelocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.linearVelocity.y);

        animator.SetFloat(AnimationStrings.yVelocity, rb.linearVelocity.y);

        if (touchingDirections.IsGrounded)
        {
            jumpCount = 0;
        }

    }



    public void OnMove(InputAction.CallbackContext context)
    {
        
        moveInput = context.ReadValue<Vector2>();
        if (IsAlive)
        {
            IsMoving = moveInput != Vector2.zero;

            SetFacingDirection(moveInput);
        }
        else
        {
            IsMoving= false;
        }
        
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            // Face right
            IsFacingRight = true;
        }
        else if(moveInput.x < 0 && IsFacingRight)
        {
            // Face left
            IsFacingRight = false;
        }
    }

    


public void OnJump(InputAction.CallbackContext context)
{
    // Check if the character is alive 
        jumpCount++;

    if (context.started && (touchingDirections.IsGrounded || jumpCount <= maxJumpCount) && CanMove)
    {
            
            animator.SetTrigger(AnimationStrings.jump);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpImpule);
    }

    if (context.canceled && rb.linearVelocity.y > 0f && CanMove)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
    }
}

    public void OnRestart(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene(0);
        }
    }


    public void incWalkSpeed()
    {
        Debug.Log("MS increased");

        walkSpeed += 2f;
    }

    public void incJump()
    {
        Debug.Log("Jump increased");
        jumpImpule += 1f;
    }

    public void incJumpCount()
    {
        Debug.Log("Jump count increased");
        maxJumpCount += 1;
    }

}

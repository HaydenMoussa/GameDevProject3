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
    public float glideSpeed = 1f; 
    private bool isGliding = false;

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
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);

        if (isGliding && !touchingDirections.IsGrounded)
        {
            // Reduce vertical velocity to create a gliding effect
            rb.velocity = new Vector2(rb.velocity.x, -glideSpeed);
        }

        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
        
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
        //check if alive as well
        
        if (context.started && touchingDirections.IsGrounded && CanMove)
        {
            animator.SetTrigger(AnimationStrings.jump);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpule);
        }

        if (context.canceled && rb.velocity.y > 0f && CanMove)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }

    public void OnRestart(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene(0);
        }
    }


}

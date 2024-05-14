using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("VARIABLES")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Header("CONTROLS")]
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;

    [Header("DRAGABLE GAMEOBJECTS")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private bool canJump = false;
    private bool isFacingRight = true;

    float horizontalMovement;

    enum MovementState
    {
        e_Idle,
        e_Move,
        e_Jump,
        e_Fall
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw(inputNameHorizontal) * moveSpeed;

        if (Input.GetButtonDown(inputNameVertical) && canJump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }

        if (horizontalMovement < 0)
        {
            //transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingRight = false;
        }

        else if (horizontalMovement > 0)
        {
            //transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            transform.localScale = new Vector3(1, 1, 1);
            isFacingRight = true;
        }

        UpdateAnimationState();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
    }

    public void OnPlatform()
    {
        canJump = true;
    }

    public void OffPlatform()
    {
        // Set coyote time here
        canJump = false;
    }

    public bool IsFacingRight()
    {
        return isFacingRight;
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (horizontalMovement != 0f)
        {
            state = MovementState.e_Move;
        }

        else
        {
            state = MovementState.e_Idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.e_Jump;
        }

        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.e_Fall;
        }

        animator.SetInteger("State", (int)state);
    }
}

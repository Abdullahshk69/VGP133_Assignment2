using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("Dragable Objects")]
    [SerializeField] TrailRenderer trailRenderer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] SpriteRenderer hairSpriteRenderer;
    [SerializeField] GameObject hair;

    [Header("Dashing")]

    [SerializeField, Tooltip("The speed with which you dash")] private float dashingVelocity = 14f;
    [SerializeField, Tooltip("The duration of dash")] private float dashingTime = 0.5f;

    private Vector2 dashingDirection;
    private bool isDashing;
    private bool canDash = true;
    private SpriteRenderer[] hairParts;
    private SpriteRenderer[] hairAnchorParts;

    private void Start()
    {
        hairParts = hair.GetComponentsInChildren<SpriteRenderer>();
        hairAnchorParts = hairParts[hairParts.Length - 1].GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Dash") && canDash)
        {
            canDash = false;
            playerMovement.enabled = false;
            isDashing = true;
            trailRenderer.emitting = true;
            dashingDirection = new Vector2(Input.GetAxisRaw("Horizontal 2"), Input.GetAxisRaw("Jump 2"));

            Color color;
            if (ColorUtility.TryParseHtmlString("#32ACAB", out color))
            {
                for (int i = 0; i < hairParts.Length; i++)
                {
                    hairParts[i].color = color;
                }

                for (int i = 1; i < hairAnchorParts.Length; i++)
                {
                    hairAnchorParts[i].color = color;
                }

                //hairSpriteRenderer.color = color;
            }

            if (dashingDirection == Vector2.zero)
            {
                dashingDirection = new Vector2(transform.localScale.x, 0);
            }
            StartCoroutine(StopDashing());

        }

        if (isDashing)
        {
            rb.velocity = dashingDirection.normalized * dashingVelocity;
        }
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        isDashing = false;
        playerMovement.enabled = true;
        rb.velocity = new Vector2(rb.velocity.x, 0);
    }

    private void FixedUpdate()
    {
        animator.SetInteger("State", 4);
    }

    public void ResetDash()
    {
        if(!isDashing)
        {
            canDash = true;
            Color color;
            if (ColorUtility.TryParseHtmlString("#AC3232", out color))
            {
                for (int i = 0; i < hairParts.Length; i++)
                {
                    hairParts[i].color = color;
                }

                for (int i = 1; i < hairAnchorParts.Length; i++)
                {
                    hairAnchorParts[i].color = color;
                }
            }
        }
    }
}

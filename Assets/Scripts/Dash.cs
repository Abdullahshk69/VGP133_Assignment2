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

    private void Update()
    {
        if (Input.GetButtonDown("Dash"))
        {
            playerMovement.enabled = false;
            isDashing = true;
            trailRenderer.emitting = true;
            dashingDirection = new Vector2(Input.GetAxisRaw("Horizontal 2"), Input.GetAxisRaw("Jump 2"));

            Color color;
            if (ColorUtility.TryParseHtmlString("#32ACAB", out color))
            {
                hairSpriteRenderer.color = color;
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
        Color color;
        if (ColorUtility.TryParseHtmlString("#AC3232", out color))
        {
            hairSpriteRenderer.color = color;
        }

    }

    private void FixedUpdate()
    {
        animator.SetInteger("State", 4);
    }
}

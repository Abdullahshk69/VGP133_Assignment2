using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairMovement : MonoBehaviour
{
    [Header("Hair Offset (Assume facing right)")]
    [SerializeField] private Vector2 idleOffset;
    [SerializeField] private Vector2 runOffset;
    [SerializeField] private Vector2 jumpOffset;
    [SerializeField] private Vector2 fallOffset;

    [Header("DRAGABLE FIELDS")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private HairAnchor hairAnchor;
    [SerializeField] PlayerMovement playerMovement;

    private void FixedUpdate()
    {
        UpdateHairOffset();
    }

    private void UpdateHairOffset()
    {
        Vector2 currentOffset = Vector2.zero;

        // idle
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            
            currentOffset = idleOffset;
        }

        // jumping
        else if (rb.velocity.y > 0)
        {
            currentOffset = jumpOffset;
        }

        // falling
        else if (rb.velocity.y < 0)
        {
            currentOffset = fallOffset;
        }

        // running
        else if (rb.velocity.x != 0)
        {
            currentOffset = runOffset;
        }

        // flip x offset if facing left
        if (!playerMovement.IsFacingRight())
        {
            currentOffset.x *= -1;
        }

        hairAnchor.partOffset = currentOffset;
    }
}

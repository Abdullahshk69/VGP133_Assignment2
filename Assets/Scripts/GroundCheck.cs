using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Dash dash = null;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            playerMovement.OnPlatform();

        if (dash != null)
        {
            if (collision.gameObject.tag == "Platform")
            {
                dash.ResetDash();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            playerMovement.OffPlatform();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] SpriteRenderer attackSprite;

    void Update()
    {
        if (Input.GetButtonDown("Parry"))
        {
            boxCollider2D.enabled = true;
            attackSprite.enabled = true;
            Invoke(nameof(ToggleBoxCollider), 0.5f);
        }
    }

    void ToggleBoxCollider()
    {
        boxCollider2D.enabled = false;
        attackSprite.enabled = false;
    }
}

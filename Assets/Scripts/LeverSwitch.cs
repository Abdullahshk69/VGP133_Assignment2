using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.localScale = new Vector3(-1, 1, 1);
            GameManager.Instance.LeverDecrement();
        }
    }
}

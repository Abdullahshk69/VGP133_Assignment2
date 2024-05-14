using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionEnemy : MonoBehaviour
{
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] boundaries = GameObject.FindGameObjectsWithTag("Boundary");

        for (int i = 0; i < players.Length; i++)
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), players[i].GetComponent<BoxCollider2D>());
        }

        for (int i = 0; i < boundaries.Length; i++)
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), boundaries[i].GetComponent<BoxCollider2D>());
        }
    }

}

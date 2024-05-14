using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

    public void Respawn()
    {
        transform.position = respawnPoint.position;
    }
}

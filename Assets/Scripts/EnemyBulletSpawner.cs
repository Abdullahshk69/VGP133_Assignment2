using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private float timer = 0.0f;

    private void FixedUpdate()
    {
        if (timer > 3.0f)
        {
            timer = 0.0f;
            SpawnBullet();
        }
        timer += Time.deltaTime;
    }

    private void SpawnBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}

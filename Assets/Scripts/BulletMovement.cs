using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Transform[] players;
    private Vector2 target;
    [SerializeField] private float moveSpeed;
    private Vector2 direction;

    bool targetEnemy;

    private void Start()
    {
        targetEnemy = false;
        // Get transform of all players using tag
        if (players == null)
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Player");
            players = new Transform[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                players[i] = temp[i].transform;
            }

            if(players.Length == 0)
            {
                Destroy(gameObject);
            }
        }

        target = new Vector2(players[Random.Range(0, players.Length)].position.x, players[Random.Range(0, players.Length)].position.y);

        direction = ((new Vector2(transform.position.x, transform.position.y) - target) * -1).normalized * moveSpeed;

        Destroy(gameObject, 4f);
    }

    private void FixedUpdate()
    {
        transform.Translate(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(1);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Enemy" && targetEnemy)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            Destroy(gameObject);
        }

        else if(collision.gameObject.tag == "Parry")
        {
            Vector2 newTarget = GameObject.FindWithTag("Enemy").transform.position;
            target = newTarget;
            direction = ((new Vector2(transform.position.x, transform.position.y) - target) * -1).normalized * moveSpeed;
            targetEnemy = true;
        }
    }
}

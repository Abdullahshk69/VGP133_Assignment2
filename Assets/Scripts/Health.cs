using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;

    [SerializeField] private float iFrame;  // To prevent taking more damage

    [SerializeField] private PlayerMovement playerMovement;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if (tag == "Player")
            {
                playerMovement.enabled = false;
                GameManager.Instance.GameOver();
            }

            else
            {
                Destroy(gameObject, 0.9f);
            }
        }
    }

    public void Heal(int heal)
    {
        health += heal;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}

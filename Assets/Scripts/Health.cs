using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private string playerName;
    [SerializeField] private int maxHealth;
    [SerializeField] TextMeshProUGUI playerHealth = null;
    private int health;

    private void Start()
    {
        health = maxHealth;
        if (playerHealth != null)
        {
            playerHealth.text = playerName + ": " + health;
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(playerHealth != null)
        {
            playerHealth.text = playerName + ": " + health;
        }

        if (health <= 0)
        {
            if (tag == "Player")
            {
                GameManager.Instance.LoseScreen();
            }

            else
            {
                GameManager.Instance.EnemyDecrement();
                Destroy(gameObject, 0.9f);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int enemyCount;
    private int leverCount;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            leverCount = GameObject.FindGameObjectsWithTag("Lever").Length;
        }
    }

    public void GameOver()
    {
        // You lose
        Invoke(nameof(LevelScene), 1.0f);
    }

    public void LevelScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void WinScreen()
    {
        SceneManager.LoadScene("Win");
    }

    public void LoseScreen()
    {
        SceneManager.LoadScene("Lose");
    }

    public void EnemyDecrement()
    {
        enemyCount--;
        if (enemyCount <= 0 && leverCount <= 0)
            WinScreen();
    }

    public void LeverDecrement()
    {
        leverCount--;
        if (enemyCount <= 0 && leverCount <= 0)
            WinScreen();
    }
}

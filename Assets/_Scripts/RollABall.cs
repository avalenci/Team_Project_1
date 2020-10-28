using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollABall : MonoBehaviour
{
    public GameObject[] boards;
    public Text uiTime;
    public Text uiLives;
    public Text uiLevel;

    public int lives = 1;
    public double subTime;
    public bool stopTimer = false;
    public int level;
    public GameObject board;
    public int highestLevel;
    public int time;
    public int bestTime;
    public bool highScore = false;
    static public bool gameOver = false;

    void Start()
    {
        subTime = Time.time;
        level = 0;
        StartLevel();
    }

    void StartLevel()
    {
        stopTimer = false;

        if (lives == 0 || level == boards.Length)
        {
            time = (int)(Time.time - subTime);   
            GameOver();
        }

        if (board != null)
        {
            Destroy(board);
        }

        board = Instantiate<GameObject>(boards[level]);
    }

    void GameOver()
    {
        if (level > highestLevel)
        {
            highestLevel = level;
            highScore = true;
        } else if (level == highestLevel && time < bestTime)
        {
            bestTime = time;
            highScore = true;
        }
        stopTimer = true;
        gameOver = true;
    }

    void FixedUpdate()
    {
        if (Goal.isWin)
        {
            Invoke("NextLevel", 2f);
            Goal.isWin = false;
        }

        if (Hole.isLose)
        {
            Invoke("StartLevel", 2f);
            Hole.isLose = false;
            lives--;
        }

        UpdateGUI();
    }

    void UpdateGUI()
    {
        if (!stopTimer)
        {
            uiTime.text = "Time: " + (int)(Time.time - subTime);
        }
        uiLives.text = "Lives: " + lives;
        uiLevel.text = "Level " + (level + 1)          ;
    }

    void NextLevel()
    {
        level++;
        StartLevel();
    }
}

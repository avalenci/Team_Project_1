using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RollABall : MonoBehaviour
{
    public GameObject[] boards;
    public Text uiTime;
    public Text uiLives;
    public Text uiLevel;
    public Text uiScore;
    public Button uiReset;

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
        if (PlayerPrefs.HasKey("HighestLevel"))
        {
            highestLevel = PlayerPrefs.GetInt("HighestLevel");
        }
        else
        {
            PlayerPrefs.SetInt("HighestLevel", 0);
        }
        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetInt("BestTime");
        }
        else
        {
            PlayerPrefs.SetInt("BestTime", 1000000);
        }

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

        board = Instantiate(boards[level]);
    }

    void GameOver()
    {
        uiScore.text = string.Format("Level: {0}\nTime: {1}", level, time);

        if (level > highestLevel)
        {
            highestLevel = level;
            uiScore.text += "\nNew Highscore!";
            PlayerPrefs.SetInt("HighestLevel", highestLevel);
        } else if (level == highestLevel && time < bestTime)
        {
            bestTime = time;
            uiScore.text += "\nNew Highscore!";
            PlayerPrefs.SetInt("BestTime", bestTime);
        }
        stopTimer = true;
        gameOver = true;
    }

    public void StartOver()
    {
        stopTimer = true;
        gameOver = false;
        SceneManager.LoadScene("Play_Scene");
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
        uiLevel.text = "Level " + (level + 1);
    }

    void NextLevel()
    {
        level++;
        StartLevel();
    }
}

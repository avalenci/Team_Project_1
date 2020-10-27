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

    public int lives = 3;
    public double subTime;
    public bool stopTimer = false;
    public int level;
    public GameObject board;

    void Start()
    {
        subTime = 0;
        level = 0;
        StartLevel();
    }

    void StartLevel()
    {
        stopTimer = false;
        subTime = Time.time;

        if (lives == 0)
        {
            SceneManager.LoadScene("Play_Scene");
        }

        if (board != null)
        {
            Destroy(board);
        }

        board = Instantiate<GameObject>(boards[level]);
    }

    void FixedUpdate()
    {
        if (Goal.isWin)
        {
            Invoke("NextLevel", 2f);
            Goal.isWin = false;
            stopTimer = true;
        }

        if (Hole.isLose)
        {
            Invoke("StartLevel", 2f);
            Hole.isLose = false;
            lives--;
            stopTimer = true;
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
    }

    void NextLevel()
    {
        level++;
        StartLevel();
    }
}

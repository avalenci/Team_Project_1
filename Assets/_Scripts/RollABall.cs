using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollABall : MonoBehaviour
{
    public GameObject[] boards;
    public Text uiTime;

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
        if (board != null)
        {
            Destroy(board);
        }

        board = Instantiate<GameObject>(boards[level]);
    }

    void Update()
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
        }

        if (!stopTimer)
        {
            UpdateGUI();
        }
    }

    void UpdateGUI()
    {
        uiTime.text = "Time: " + (int)(Time.time - subTime);
    }

    void NextLevel()
    {
        level++;
        stopTimer = false;
        subTime = Time.time;
        StartLevel();
    }
}

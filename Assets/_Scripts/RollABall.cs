using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollABall : MonoBehaviour
{
    public GameObject[] boards;

    public int level;
    public GameObject board;

    void Start()
    {
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
        }

        if (Hole.isLose)
        {
            Invoke("StartLevel", 2f);
            Hole.isLose = false;
        }
    }

    void NextLevel()
    {
        level++;
        StartLevel();
    }
}

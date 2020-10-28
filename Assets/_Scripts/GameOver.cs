using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public float currentTime = 0.0f, executedTime = 0.0f, timeToWait = 1.0f;
    public Text text;
    public Button button;
    public Image image;

    private void Start()
    {
        text.enabled = false;
        button.enabled = false;
        image = button.GetComponent<Image>();
        image.enabled = false;
    }

    public void OnClick()
    {   
        executedTime = Time.time;
    }

    void Update()
    {
        currentTime = Time.time;
        if (RollABall.gameOver)
        {
            text.enabled = true;
            button.enabled = true;
            image.enabled = true;
        } 
        else
        {
            text.enabled = false;
            button.enabled = false;
            image.enabled = false;
        }

        if (executedTime != 0.0f)
        {
            if (currentTime - executedTime > timeToWait)
            {
                executedTime = 0.0f;
                RollABall.gameOver = false;
                SceneManager.LoadScene("Play_Scene");
            }
        }
    }
}

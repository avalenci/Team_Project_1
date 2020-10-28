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
    public Image resetImage;

    public Color tempColor;

    private void Start()
    {
        text.enabled = false;
        button.enabled = false;
        image = button.GetComponent<Image>();
        resetImage = GameObject.Find("UI_Restart").GetComponent<Image>();
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
            tempColor = resetImage.color;
            resetImage.color = Color.gray;
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
            resetImage.color = tempColor;
            executedTime = 0.0f;
            RollABall.gameOver = false;
            SceneManager.LoadScene("Play_Scene");
        }
    }
}

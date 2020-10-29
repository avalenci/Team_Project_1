using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text text;
    public Image image;

    private void Start()
    {
        text.enabled = false;
        image.enabled = false;
    }

    void Update()
    {
        if (RollABall.gameOver)
        {
            text.enabled = true;
            image.enabled = true;
        } 
        else
        {
            text.enabled = false;
            image.enabled = false;
        }
    }
}

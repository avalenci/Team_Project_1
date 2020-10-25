using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool isWin = false;

    private void OnTriggerEnter(Collider other)
    {
        isWin = true;
    }
}

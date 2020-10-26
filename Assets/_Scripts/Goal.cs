using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool isWin = false;

    private void OnTriggerEnter(Collider other)
    {
        isWin = true;

        GameObject ball = GameObject.Find("Ball");

        ball.GetComponent<Rigidbody>().constraints =
            RigidbodyConstraints.FreezePositionX
            | RigidbodyConstraints.FreezePositionZ;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    static public bool isLose = false;

    private void OnTriggerEnter(Collider other)
    {
        isLose = true;
        other.enabled = false;

        GameObject ball = GameObject.Find("Ball");

        ball.GetComponent<Rigidbody>().constraints =
            RigidbodyConstraints.FreezePositionX
            | RigidbodyConstraints.FreezePositionZ;
    }
}
